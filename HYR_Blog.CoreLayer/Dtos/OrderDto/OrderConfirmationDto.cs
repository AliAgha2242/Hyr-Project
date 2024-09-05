using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYR_Blog.CoreLayer.Dtos.OrderDto
{
    public class OrderConfirmationDto
    {
        public string FullName { get; set; }
        public string State { get; set; }
        public string City { get; set; }

        public string PostalCode { get; set; }
        public string ContinueAddress { get; set; }
        public string PhoneNumber { get; set; }
        public int UserId { get; set; }

    }
}
