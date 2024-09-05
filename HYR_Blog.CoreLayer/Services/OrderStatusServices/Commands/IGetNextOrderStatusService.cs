using HYR_Blog.CoreLayer.Dtos.OrderStatusDto;
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
    public interface IGetNextOrderStatusService
    {
        MyResult<OrderStatusDto> GetNextStatus(int Priority);
    }

    public class GetNextOrderStatusService : IGetNextOrderStatusService
    {
        private readonly HyrDbContext _dbContext;
        public GetNextOrderStatusService(HyrDbContext hyrDbContext)
        {
            _dbContext = hyrDbContext;
        }
        public MyResult<OrderStatusDto> GetNextStatus(int Priority)
        {
            if (Priority <= 0 || Priority == null)
                return MyResult<OrderStatusDto>.Failed(new OrderStatusDto(),StatusMessage:"مشکلی در الویت پیش آمده است");
            
            int nextPriority = Priority+1;
            if (nextPriority == 2)
                nextPriority = nextPriority+1;

            OrderStatus? OrderStatus = _dbContext.OrderStatus.FirstOrDefault(x => x.Priority == nextPriority);
            if (OrderStatus == null)
                return MyResult<OrderStatusDto>.Failed(new OrderStatusDto(),StatusMessage:"وضعیت بعدی یافت نشد");

            return MyResult<OrderStatusDto>.Success(data:new OrderStatusDto()
            {
                OrderStatusId = OrderStatus.StatusId,
                OrderStatusPriority = OrderStatus.Priority,
                OrderStatusTitle = OrderStatus.StatusTitle
            });
        }
    }
}





