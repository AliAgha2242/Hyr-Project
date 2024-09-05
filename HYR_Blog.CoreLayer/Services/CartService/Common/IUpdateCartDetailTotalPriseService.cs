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

namespace HYR_Blog.CoreLayer.Services.CartService.Common
{
    public interface IUpdateCartDetailTotalPriseService
    {
        MyResult<UpdateCartDetailDto> UpdateCartDetailTotalPrise(UpdateCartDetailDto CartDetail);
    }
    public class UpdateCartDetailTotalPriseService : IUpdateCartDetailTotalPriseService
    {
        private readonly HyrDbContext _dbContext;
        public UpdateCartDetailTotalPriseService(HyrDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public MyResult<UpdateCartDetailDto> UpdateCartDetailTotalPrise(UpdateCartDetailDto CartDetail)
        {


            #region CartDetailValid


            if (string.IsNullOrWhiteSpace(CartDetail.CartCode) && (CartDetail.UserId == null || CartDetail.UserId < 0))
                return MyResult<UpdateCartDetailDto>.Failed(null, StatusMessage: "سبد خرید شما یافت نشد");


            Cart? cart = _dbContext.Carts.Include(c => c.CartItems)
               .ThenInclude(c => c.Product)
               .FirstOrDefault(c => c.UserId == CartDetail.UserId);

            if (cart == null)
            {
                cart = _dbContext.Carts.FirstOrDefault(c => c.CartCode == CartDetail.CartCode);
                if (cart == null)
                    return MyResult<UpdateCartDetailDto>.NotFound(null, StatusMessage: "سبد خرید شما یافت نشد");
            }



            #endregion

            //TotalPrise
            int TotalPrise = cart.CartItems.Select(ci => ci.Product.PriseByDiscount ?? ci.Product.Prise).Sum();
            //tottalWeight 
            int? TotalWeight = cart.CartItems.Select(c => c.Product.Weight).Sum();

            //return Varible
            UpdateCartDetailDto cartDto = new UpdateCartDetailDto();
            // find TransportationTable And config TotalPrise WithTransportPrise  without DiscountAmount
            Transportation? transportation = _dbContext.Transportations.Find(CartDetail.TransportationId);
            int? TotalPriseWithTranspotationPrise = TranspotationHelps.ConfigTransportationPrise(TotalWeight, transportation.InitialPrise,
                transportation.PrisePerKg) + TotalPrise;


            //validation discountCode
            if (CartDetail.DiscountCode != null)
            {
                if (DiscountValidOutDiscountAmount(CartDetail.DiscountCode, out int Amount) == true)
                {
                    cartDto.TotalPriseWithTransportationPriseAndDiscount = (Convert.ToInt32(TotalPriseWithTranspotationPrise) - Amount);

                    cartDto.TotalPriseWithTransportationPriseAndDiscount = Convert.ToInt32(TotalPriseWithTranspotationPrise) - Amount;
                    cart.TransportationId = CartDetail.TransportationId;
                    cart.TotalPrise = Convert.ToInt32(TotalPriseWithTranspotationPrise);

                    return MyResult<UpdateCartDetailDto>.Success(cartDto);
                }
                else
                {
                    cartDto.TotalPriseWithTransportationPriseAndDiscount = Convert.ToInt32(TotalPriseWithTranspotationPrise);

                    cartDto.TotalPriseWithTransportationPriseAndDiscount = Convert.ToInt32(TotalPriseWithTranspotationPrise);
                    cart.TransportationId = CartDetail.TransportationId;
                    cart.TotalPrise = Convert.ToInt32(TotalPriseWithTranspotationPrise);

                    return MyResult<UpdateCartDetailDto>.Duplicate(cartDto, StatusMessage: "متاسفانه کد تخفیف شما معتبر نیست");
                }
            }


            cartDto.TotalPriseWithTransportationPriseAndDiscount = Convert.ToInt32(TotalPriseWithTranspotationPrise);
            cart.TransportationId = CartDetail.TransportationId;
            cart.TotalPrise = Convert.ToInt32(TotalPriseWithTranspotationPrise);


            _dbContext.Carts.Update(cart);
            _dbContext.SaveChanges();
            return MyResult<UpdateCartDetailDto>.Success(cartDto);
        }

        private bool DiscountValidOutDiscountAmount(string discountText, out int discountAmount)
        {
            if (_dbContext.DiscountCodes.Any(d => d.DisCountCodeText == discountText))
            {
                var DiscountCode = _dbContext.DiscountCodes.Single(d => d.DisCountCodeText == discountText);
                int result = DateTime.Compare(DiscountCode.EndDate, DateTime.Now);
                if (result > 0 && DiscountCode.UseCountAllowed > DiscountCode.UseCount)
                {
                    discountAmount = DiscountCode.DisCountAmount;
                    return true;
                }


                discountAmount = 0;
                return false;

            }
            discountAmount = 0;
            return false;
        }
    }
}
