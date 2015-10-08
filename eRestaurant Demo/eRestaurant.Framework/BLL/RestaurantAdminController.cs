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
        [DataObjectMethod(DataObjectMethodType.Update, false)]
        public void UpdateSpecialEvent(SpecialEvent item)
        { 
            using(RestaurantContext context = new RestaurantContext())
            {
                //First attach the item to the dbContext collection
                var attached = context.SpecialEvents.Attach(item);
                //Second, get the entry for the existing data that should match for
                //this specific special event
                var existing = context.Entry<SpecialEvent>(attached);

                //Third, mark that the object's values have changed
                existing.State = System.Data.Entity.EntityState.Modified;
                //Lastly, save the changes in the database
                context.SaveChanges();
            }
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public void DeleteSpecialEvent(SpecialEvent item)
        {
            using(RestaurantContext context = new RestaurantContext())
            {
                //First, get a reference to the actual item in the Db
                //Find() is a method to look up an item by its primary key
                var existing = context.SpecialEvents.Find(item.EventCode);

                //Second, remove the item from the database context
                context.SpecialEvents.Remove(existing);

                //Lastly, save the changes to the database
                context.SaveChanges();
            }
        }
        [DataObjectMethod(DataObjectMethodType.Insert,false)]
        public void InsertSpecialEvent(SpecialEvent item)
        {
            using(var context = new RestaurantContext())
            {
                //Add the item to the dbContext
                var added = context.SpecialEvents.Add(item);
                //This only shows that the Add() object will return the newly added object

                //Save the changes to the database
                context.SaveChanges();
            }
        }
    }
}
