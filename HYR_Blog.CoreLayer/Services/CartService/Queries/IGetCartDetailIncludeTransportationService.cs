using HYR_Blog.CoreLayer.Dtos.CartDto;
using HYR_Blog.CoreLayer.Utilities.OperationResult;
using HYR_Blog.CoreLayer.Utilities.TransportationHelp;
using HYR_Blog.DataLayer.Context;
using HYR_Blog.DataLayer.Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYR_Blog.CoreLayer.Services.CartService.Queries
{
    public interface IGetCartDetailIncludeTransportationService
    {
        MyResult<CartDetailDto> GetCartDetailIncludeTransportation(int? UserId,string? CartCode);
    }
    public class GetCartDetailIncludeTransportationService : IGetCartDetailIncludeTransportationService
    {
        private readonly HyrDbContext _context;
        public GetCartDetailIncludeTransportationService(HyrDbContext context)
        {
            _context = context;
        }
        public MyResult<CartDetailDto> GetCartDetailIncludeTransportation(int? UserId, string? CartCode)
        {
            if(string.IsNullOrWhiteSpace(CartCode) &&( UserId == null || UserId < 0))
                return MyResult<CartDetailDto>.Failed(null);



            Cart? cart = _context.Carts.Include(c => c.CartItems)
                .ThenInclude(c=>c.Product)
                .FirstOrDefault(c => c.UserId == UserId && !c.IsFinish);

            if (cart == null)
            {
                cart = _context.Carts.Include(c => c.CartItems).FirstOrDefault(c => c.CartCode == CartCode);
                if (cart == null)
                    return MyResult<CartDetailDto>.NotFound(null);
            }



            int? TotalPrise = TranspotationHelps.ConfigTransportationPrise(cart.CartItems.Select(ci=>ci.Product.Weight).Sum(),
                _context.Transportations.First().InitialPrise ,
                 _context.Transportations.First().PrisePerKg);



            int? Weight = cart.CartItems.Select(ci=>ci.Product.Weight).Sum();
            List<TransportationDto> transportations = _context.Transportations.Select(t=>new TransportationDto()
            {
                InitialPrise = t.InitialPrise,
                PrisePerKg = t.PrisePerKg,
                TransportationCompany = t.TransportationCompany,
                TransportationId = t.TransportationId,
            }).ToList();

            transportations.Select(t=>
            t.SendPriseByWeight = Convert.ToInt32(TranspotationHelps.ConfigTransportationPrise(Weight,t.InitialPrise,t.PrisePerKg))
            ).ToList();

            var TotalPriseWithTransportation = Convert.ToInt32(TotalPrise) + cart.CartItems.Select(ci=>ci.Product.PriseByDiscount??ci.Product.Prise).Sum();

            CartDetailDto cartDto = new CartDetailDto()
            {
                TotalPrise = cart.CartItems.Select(ci=>ci.Product.PriseByDiscount??ci.Product.Prise).Sum(),
                TotalPriseWithTransportation = TotalPriseWithTransportation,
                transportations = transportations,
                TotalWeight = Convert.ToInt32(Weight)
            };

             cart.TransportationId = _context.Transportations.First().TransportationId;
            cart.TotalPrise = TotalPriseWithTransportation;
            _context.Carts.Update(cart);
            _context.SaveChanges();

            return  MyResult<CartDetailDto>.Success(cartDto);

           

        }

        //Give TotalPrise With This Algoritm 
        
    }
}
