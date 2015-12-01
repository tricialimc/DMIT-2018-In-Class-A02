using eRestaurant.Framework.Entities.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurant.Framework.Entities.DTOs
{
    public class Order
    {
        public int BillID { get; set; }
        public IEnumerable<OrderItem> Items { get; set; }
    }
}
