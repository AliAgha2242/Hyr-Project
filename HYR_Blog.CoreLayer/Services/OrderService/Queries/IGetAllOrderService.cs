using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HYR_Blog.CoreLayer.Dtos.OrderDto;
using HYR_Blog.CoreLayer.Utilities.OperationResult;
using HYR_Blog.CoreLayer.Utilities.Other;
using HYR_Blog.DataLayer.Context;
using HYR_Blog.DataLayer.Entitys;
using Microsoft.EntityFrameworkCore;

namespace HYR_Blog.CoreLayer.Services.OrderService
{
    public interface IGetAllOrderService
    {
        MyResult<List<ShowOrderDto>> GetAllOrders();
    }
    public class GetAllOrderService:IGetAllOrderService
    {
        private readonly HyrDbContext _dbContext;

        public GetAllOrderService(HyrDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public MyResult<List<ShowOrderDto>> GetAllOrders()
        {
            List<Order> orders = _dbContext.Orders.Include(o => o.User)
                .Include(o=>o.OrderStatus)
                .Include(o=>o.User).ThenInclude(u=>u.Address)
                .Include(o=>o.OrderDetails).ThenInclude(od=>od.Product)
                .ToList();


            List<ShowOrderDto> orderDtos = orders.Select(o => new ShowOrderDto()
            {
                CreationDate = DateTimeConverter.ConvertToPersian(o.CreationDate),
                PersonName = o.User.FullName,
                SendCode = o.SendCode,
                SerialNumber = o.SerialNumber,
                SumPrise = o.OrderDetails.Select(od => od.Product.PriseByDiscount??od.Product.Prise).Sum(),
                Status = o.OrderStatus.StatusTitle,
                Address = AddressConfig.FullAddress(o.User.Address.State,
                o.User.Address.City,o.User.Address.ContinueAddress),
                NameAndCountProduct = new Dictionary<string, int>(_dbContext.OrderDetails.Where(od => od.OrderId == o.OrderId).GroupBy(od => od.ProductId).Select(g=>new KeyValuePair<string, int>(g.First()
                .Product.ProductName , g.Count()))),
                StatusPriority = o.OrderStatus.Priority,
                OrderId = o.OrderId,

                //NameAndCountProduct = new Tuple<List<string>, List<int>>(_dbContext.OrderDetails.Where(od => od.OrderId == o.OrderId)
                //.Select(od => od.Product.ProductName).Distinct().ToList(),
                //_dbContext.OrderDetails.Where(od => od.OrderId == o.OrderId).GroupBy(od => od.ProductId).Select(g => g.Count()).ToList())

            }).ToList();

            return MyResult<List<ShowOrderDto>>.Success(orderDtos);

        }
    }
}
