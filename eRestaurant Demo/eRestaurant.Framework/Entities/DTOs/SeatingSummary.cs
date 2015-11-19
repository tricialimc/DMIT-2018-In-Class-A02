using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurant.Framework.Entities.DTOs
{
    public class SeatingSummary
    {
        public byte Table { get; set; } // the table number - Tables.TableNumber
        public int Seating { get; set; } //seating capacity -Tables.Capacity
        public bool Taken { get; set; } // calculated - true if occupied
        public int? BillID { get; set; } //Bills.BillID (nullable)
        public decimal? BillTotal { get; set; } //calculated - total bill (nullable)
        public string Waiter { get; set; } //Waiter's name (nullable)
        public string ReservationName { get; set; } //Reservations.ContactName (nullable)
        

    }
}
