using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eRestaurant.Framework.DAL;
using eRestaurant.Framework.Entities;
using System.ComponentModel;

namespace eRestaurant.Framework.BLL
{
    [DataObject] //allow our class to be "discovered" by the ObjectDataSource controls in our website
    public class RestaurantAdminController
    {
        //The ObjectDataSource control will do the background communication for CRUD operations
        //allows the ObjectDataSource to see the method as something we can SELECT from
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<SpecialEvent> ListAllSpecialEvents()
        {
            //This using statement ensures that our connection to the database is 
            //properly "closed" once we are done "using" our DAL objects.
            //(context is our DAL object)
            using (RestaurantContext context = new RestaurantContext())
            {
                return context.SpecialEvents.ToList();
            }
        }
    }
}
