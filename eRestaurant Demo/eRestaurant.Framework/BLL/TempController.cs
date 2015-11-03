using eRestaurant.Framework.DAL; // Access the DAL class
using eRestaurant.Framework.Entities; // Access the namespace for my entity classes
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurant.Framework.BLL
{
    [DataObject]
    public class TempController
    {
        public List<MenuCategory> ListMenuCategories()
        {
            using(var context = new RestaurantContext())
            {
                var data = from category in context.MenuCategories
                           select category;
                return data.ToList();
            }
        }
        
        
        #region LastBillDate
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public DateTime GetLastBillDateTime()
        {
            using (var context = new RestaurantContext())
            {
                var result = context.Bills.Max(row => row.BillDate);
                return result;
            }
        }
        #endregion
    }
}
