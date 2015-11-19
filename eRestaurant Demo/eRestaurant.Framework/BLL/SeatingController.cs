﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eRestaurant.Framework.Entities.DTOs;
using eRestaurant.Framework.DAL;
using eRestaurant.Framework.Entities;

namespace eRestaurant.Framework.BLL
{
    [DataObject]
    public class SeatingController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<SeatingSummary> SeatingByDateTime(DateTime date, TimeSpan time)
        {
            using (var context = new RestaurantContext())
            {
                //copy paste from linqpad
                //since the data type of context.Tables is a DbSet<Table>,
                //that means I can add a bit of extra to my LINQ query to declare that
                //the variable data is of type Table
                var step1 = from Table data in context.Tables
                select new
			    {
				    Table = data.TableNumber,
				    Seating = data.Capacity,
				    // This sub-query gets the bills for walk-in customers
				    WalkIns = from walkIn in data.Bills
				              where walkIn.BillDate.Year == date.Year
						         && walkIn.BillDate.Month == date.Month
							     && walkIn.BillDate.Day == date.Day
							     && (!walkIn.OrderPaid.HasValue || walkIn.OrderPaid.Value >= time)
						      select walkIn,
				    // This sub-query gets the bills for reservations
				    Reservations = from Reservation booking in data.Reservations
				                   from reservationParty in booking.Bills
							       where reservationParty.BillDate.Year == date.Year
							          && reservationParty.BillDate.Month == date.Month
								      && reservationParty.BillDate.Day == date.Day
								      && (!reservationParty.OrderPaid.HasValue || reservationParty.OrderPaid >= time)
							       select reservationParty
			    };
                        	
			
                        // Step 2 - Union the walk-in bills and the reservation bills while extracting the
                        //          relevant bill info.
                        //          .ToList() helps resolve the error
                        //          "Types in Union or Concat are constructed incompatibly"
                        var step2 = from data in step1.ToList()
                                    select new
			                        {
				                        Table = data.Table,
				                        Seating = data.Seating,
				                        CommonBilling = from info in data.WalkIns.Union(data.Reservations)
				                                        select new // trimmed down billing info
								                        {
									                        BillID = info.BillID,
									                        BillTotal = info.BillItems.Sum(bi => bi.Quantity * bi.SalePrice),
									                        Waiter = info.Waiter.FirstName,
									                        Reservation = info.Reservations
								                        }
			                        };
                        		

                        // Step 3 - Get just the first CommonBilling item
                        //          (presumes no overlaps can occur - i.e., two groups at the same
                        //          table at the same time)
                        var step3 = from data in step2.ToList()
                                    select new
			                        {
				                        Table = data.Table,
				                        Seating = data.Seating,
				                        Taken = data.CommonBilling.Count() > 0,
				                        // .FirstOrDefault() is effectively "flattening" my collection of 1 item into a
				                        // single object whose properties I can get in Step 4 using the dot (.) operator
				                        CommonBilling = data.CommonBilling.FirstOrDefault()
			                        };
                        

                        // Step4 - Build our intended seating summary info
                        var step4 = from data in step3
                                    select new SeatingSummary() // the DTO class to use in my BLL
                                    {
                                        Table = data.Table,
                                        Seating = data.Seating,
                                        Taken = data.Taken,
                                        // use a ternary expression to conditionally get the bill id (if it exists)
                                        BillID = data.Taken ?               // if(data.Taken)
                                                 data.CommonBilling.BillID  // value to use if true
                                               : (int?)null,               // value to use if false
                                        BillTotal = data.Taken ?
                                                    data.CommonBilling.BillTotal : (decimal?)null,
                                        Waiter = data.Taken ? data.CommonBilling.Waiter : (string)null,
                                        ReservationName = data.Taken ?
                                                          (data.CommonBilling.Reservation != null ?
                                                           data.CommonBilling.Reservation.CustomerName :
                                                           (string)null)
                                                        : (string)null
                                    };
                        return step4.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<ReservationCollection> ReservationsForDate(DateTime date)
        {
            using (var context = new RestaurantContext())
            { 
                var result = from eachRow in context.Reservations
                             where eachRow.ReservationDate.Year == date.Year
                                && eachRow.ReservationDate.Month == date.Month
                                && eachRow.ReservationDate.Day == date.Day
                                && eachRow.ReservationStatus == Reservation.Booked
                             select new ReservationSummary()
                             {
                                 Name = eachRow.CustomerName,
                                 Date = eachRow.ReservationDate,
                                 NumberInParty = eachRow.NumberInParty,
                                 Status = eachRow.ReservationStatus.ToString(),
                                 Event = eachRow.SpecialEvent.Description,
                                 Contact = eachRow.ContactPhone
                             };
                var finalResult = from eachItem in result
                                  group eachItem by eachItem.Date.Hour into itemGroup
                                  select new ReservationCollection()
                                  {
                                      Hour = itemGroup.Key,
                                      Reservations = itemGroup.ToList()
                                  };
                return finalResult.ToList();
            }
        }
    }
}
