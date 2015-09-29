using eRestaurant.Framework.Entities; //Needed for Entity Class
using System;
using System.Collections.Generic;
using System.Data.Entity; //Needed for the DbContext and other EF classes
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurant.Framework.DAL
{
    /*By making our DAL class internal, that means outside projects cant' directly
    access our Data Access Layer (they will have to go through our BLL to do stuff)*/
    internal class RestaurantContext : DbContext
    {
        public RestaurantContext()
            : base("eRestaurantDB")
        { }

        //One property for each Table/Entity in the database
        //The property name must match the name of the database table
        public DbSet<MenuCategory> MenuCategories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Tables> Tables { get; set; }
        public DbSet<Reservations> Reservations { get; set; }
        public DbSet<SpecialEvent> SpecialEvents { get; set; }
        public DbSet<Waiters> Waiters { get; set; }
        public DbSet<Bills> Bills { get; set; }
        public DbSet<BillItems> BillItems { get; set; }
        
        //For customizing the model of our entities as we want them to match our database, we would put any details
        //inside the following method
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservations>().HasMany(r => r.Tables)
                        .WithMany(t => t.Reservations)
                        .Map(mapping =>
                        {
                            mapping.ToTable("ReservationTables");
                            mapping.MapLeftKey("ReservationID");
                            mapping.MapRightKey("TableID");
                        });
            base.OnModelCreating(modelBuilder);
        }
    }
}
