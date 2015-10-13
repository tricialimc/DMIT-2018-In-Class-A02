using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel; //for [DataObject]
using eRestaurant.Framework.DAL; //for Restaurant Context
using eRestaurant.Framework.Entities; //for DB entities classes
using System.Data.Entity; //for the Lambda version of the Include() method

namespace eRestaurant.Framework.BLL
{
    [DataObject]
    public class MenuController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Item> ListMenuItems()
        {
            using (var context = new RestaurantContext())
            {
                return context.Items.ToList();
            }
        }


    }
}
