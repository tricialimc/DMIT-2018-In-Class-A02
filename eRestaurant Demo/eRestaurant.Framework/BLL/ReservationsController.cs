﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eRestaurant.Framework.DAL;
using eRestaurant.Framework.Entities;
using eRestaurant.Framework.Entities.POCOs;
using eRestaurant.Framework.Entities.DTOs;

namespace eRestaurant.Framework.BLL
{
    [DataObject]
    public class ReservationsController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<ActiveEvent> ListActiveEvents()
        {
            using (var context = new RestaurantContext())
            {
                var result = from eachRow in context.SpecialEvents
                             where eachRow.Active
                             select new ActiveEvent()
                             {
                                 Code = eachRow.EventCode,
                                 Description = eachRow.Description
                             };
                return result.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<DailyReservation> ListUpcomingReservations(string eventCode)
        {
            using (var context = new RestaurantContext())
            {
                //step1 will be an object that generates SQL to run on the database
                var step1 = from eachRow in context.Reservations //brings the step1 results into memory
                            where eachRow.ReservationStatus == "B" // use "B" in Visual Studio
                            //TBA - && eachRow has the correct EventCode...
                            orderby eachRow.ReservationDate
                            //select eachRow
                            group eachRow by new { eachRow.ReservationDate.Month, eachRow.ReservationDate.Day };
                //into dailyReservation
                //By calling step1.ToList(), the results of step1 are brought into RAM (memory)
                //for us to query as LINQ-To-Objects
                var result = from dailyReservation in step1.ToList()
                             select new DailyReservation()
                             {
                                 Month = dailyReservation.Key.Month,
                                 Day = dailyReservation.Key.Day,
                                 Reservations = from booking in dailyReservation
                                                select new Booking() //Create a booking POCO class
                                                {
                                                    Name = booking.CustomerName,
                                                    Time = booking.ReservationDate.TimeOfDay,
                                                    NumberInParty = booking.NumberInParty,
                                                    Phone = booking.ContactPhone,
                                                    Event = booking.SpecialEvent == null //we're doing it in memory (RAM)
                                                               ? (string)null
                                                               : booking.SpecialEvent.Description
                                                }
                             };
                return result.ToList();
            }

        }
    }
}
