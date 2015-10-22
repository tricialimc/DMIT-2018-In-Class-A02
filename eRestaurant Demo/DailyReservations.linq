<Query Kind="Statements">
  <Connection>
    <ID>f69db0fc-eee8-4c1d-ace3-fe347a652c1b</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

var step1 = from eachRow in Reservations
where eachRow.ReservationStatus == 'B' // use "B" in Visual Studio
//TBA - && eachRow has the correct EventCode...
orderby eachRow.ReservationDate
//select eachRow
group eachRow by new {eachRow.ReservationDate.Month, eachRow.ReservationDate.Day};
//into dailyReservation
var result = from dailyReservation in step1.ToList()
select new //DailyReservation()
{
	Month = dailyReservation.Key.Month,
	Day = dailyReservation.Key.Day,
	Reservations = from booking in dailyReservation
				   select new //Booking() //Create a booking POCO class
					{
						Name = booking.CustomerName,
						Time = booking.ReservationDate.TimeOfDay,
						NumberInParty = booking.NumberInParty,
						Phone = booking.ContactPhone,
						Event = booking.SpecialEvents == null 
								?(string) null
								: booking.SpecialEvents.Description
					}
};
result.Dump();