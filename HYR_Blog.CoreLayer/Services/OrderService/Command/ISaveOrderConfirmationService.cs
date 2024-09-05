using HYR_Blog.CoreLayer.Dtos.OrderDto;
using HYR_Blog.CoreLayer.Utilities.OperationResult;
using HYR_Blog.DataLayer.Context;
using HYR_Blog.DataLayer.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYR_Blog.CoreLayer.Services.OrderService.Command
{
    public interface ISaveOrderConfirmationService
    {
        MyResultWithoutData SaveOrderConfirmation(OrderConfirmationDto confirmationDto);
    }
    public class SaveOrderConfirmationService : ISaveOrderConfirmationService
    {
        private readonly HyrDbContext _dbContext;

        public SaveOrderConfirmationService(HyrDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public MyResultWithoutData SaveOrderConfirmation(OrderConfirmationDto confirmationDto)
        {
            Address address = new Address()
            {
                City = confirmationDto.City,
                ContinueAddress = confirmationDto.ContinueAddress,
                PostalCode = confirmationDto.PostalCode,
                State = confirmationDto.State,
                UserId = confirmationDto.UserId,
                
            };
            _dbContext.Add<Address>(address);
             _dbContext.SaveChanges();

            User user = _dbContext.Find<User>(confirmationDto.UserId);
            if (user == null)
                return MyResultWithoutData.NotFound();

            

            user.AddressId = address.AddressId;

            _dbContext.Update<User>(user);

            _dbContext.SaveChanges();
            return MyResultWithoutData.Success();
        }
    }
}
