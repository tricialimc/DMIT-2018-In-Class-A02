﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurant.Framework.Entities
{
    public class Bills
    {
        [Key]
        public int BillID { get; set; }
        public DateTime BillDate { get; set; }
        public DateTime? OrderPlaced { get; set; }
        public int NumberInParty { get; set; }
        public bool PaidStatus { get; set; }
        public int WaiterID { get; set; }
        public int? TableID { get; set; }
        public int? ReservationID { get; set; }
        public bool OrderReady { get; set; }
        public string Comment { get; set; }
        
        // Navigation Properties
        public virtual ICollection<BillItems> Items { get; set; }
        public virtual Waiters Waiter { get; set; }
        public virtual Tables Table { get; set; }

        public Bills()
        {
            BillDate = DateTime.Now;
        }
    }
}
