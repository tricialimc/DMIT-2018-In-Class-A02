﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurant.Framework.Entities.POCOs
{
    public class Booking
    {
        public string Name { get; set; }
        public TimeSpan Time { get; set; }
        public int NumberInParty { get; set; }
        public string Phone { get; set; }
        public string Event { get; set; }
    }
}
