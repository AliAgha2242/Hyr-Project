using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYR_Blog.DataLayer.Entitys
{
    public class Transportation
    {
        //Map With FluentApi
        public int TransportationId { get; set; }
        public string TransportationCompany { get; set; }
        public int PrisePerKg { get; set; }
        public int InitialPrise { get; set; }

        #region Relation
        public virtual List<Order> Orders { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }

        #endregion

    }
}
