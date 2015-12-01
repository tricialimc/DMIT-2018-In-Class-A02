using eRestaurant.Framework.DAL;
using eRestaurant.Framework.Entities.POCOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurant.Framework.BLL
{
    [DataObject]
    public class WaiterController
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<UnpaidBill> ListUnpaidBills()
        {
            using (var context = new RestaurantContext())
            {
                var result = from data in context.Bills
                             where !data.PaidStatus
                                 && data.BillItems.Count() > 0
                             select new UnpaidBill()
                             {
                                 DisplayText = "Bill" + data.BillID.ToString(),
                                 KeyValue = data.BillID
                             };
                return result.ToList();
            }
        }

        public object GetBill(int billId)
        {
            using (var context = new RestaurantContext())
            {
                var result = from data in context.Bills
                             where data.BillID == billId // This would be billID that they ask for
                             select new //Order()
                             {
                                 BillID = data.BillID,
                                 Items = (from info in data.BillItems
                                          select new //OrderItem()
                                         {
                                             ItemName = info.Items.Description,
                                             Price = info.SalePrice,
                                             Quantity = info.Quantity
                                         }).ToList()
                             };
                return result.FirstOrDefault();
            }
        }
    }
}
