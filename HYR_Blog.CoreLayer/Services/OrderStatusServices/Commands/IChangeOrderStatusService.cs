using HYR_Blog.CoreLayer.Utilities.OperationResult;
using HYR_Blog.DataLayer.Context;
using HYR_Blog.DataLayer.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYR_Blog.CoreLayer.Services.OrderStatusServices.Commands
{
    public interface IChangeOrderStatusService
    {
        MyResultWithoutData ChangeOrderStatus(int Priority, int OrderId, string? SendCode);
    }
    public class ChangeOrderStatusService : IChangeOrderStatusService
    {
        private readonly HyrDbContext _dbContext;
        public ChangeOrderStatusService(HyrDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public MyResultWithoutData ChangeOrderStatus(int Priority, int OrderId, string? SendCode)
        {
            if (Priority == 0)
                MyResultWithoutData.Failed();


            if (OrderId == 0)
                MyResultWithoutData.Failed();


            OrderStatus? OrderStatus = _dbContext.OrderStatus.FirstOrDefault(x => x.Priority == Priority);
            if (OrderStatus == null)
                return MyResultWithoutData.Failed();

            Order? order = _dbContext.Orders.FirstOrDefault(o => o.OrderId == OrderId);
            if (order == null)
                return MyResultWithoutData.NotFound(StatusMessage: "محصول یافت نشد");

            order.OrderStatus = OrderStatus;

            
            if (OrderStatus.StatusTitle == OrderStatusTitle.Posted)
            {
                if (SendCode == null || string.IsNullOrWhiteSpace(SendCode))
                    return MyResultWithoutData.Failed(StatusMessage: "کد مرسوله نباید کمتر از 24 کاراکتر باشد");
                if(_dbContext.Orders.Any(o=>o.SendCode == SendCode))
                    return MyResultWithoutData.Failed(StatusMessage:"این کد قبلا ثبت شده است");
                order.SendCode = SendCode;
            }

            _dbContext.Orders.Update(order);
            _dbContext.SaveChanges();

            return MyResultWithoutData.Success();

        }
    }

}
