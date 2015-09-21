<Query Kind="Expression">
  <Connection>
    <ID>f69db0fc-eee8-4c1d-ace3-fe347a652c1b</ID>
    <Server>.</Server>
    <Database>eRestaurant</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

/*Show me the reservations slated for a given Year, Month and Day (ignoring the cancelled ones). 
(For sample dates, choose May 19, 2014 and September 20, 1014).
- Advanced: Group the reservations by hour of the day*/
from reservations in Reservations
where reservations.ReservationDate.Year == 2014 &&
	  reservations.ReservationDate.Month == 9 &&
	  reservations.ReservationDate.Day == 20
group reservations by reservations.ReservationDate.Hour

/*Waiters with active customers (bills not paid)*/
from waiters in Bills
where waiters.OrderPaid == null
select waiters

/*Orders waiting to be served (sorted by table and showing the items on the order)*/
from orders in BillItems
where orders.Bill.PaidStatus == false
select new
{
  BillID = orders.BillID,
  TableID = orders.Bill.TableID,
  MenuItems=orders.Item.Description
}


/*A list of Active tables waiting to place an order*/
from bills in Bills
where bills.OrderPlaced == null
select bills.TableID


/*Items to prepare for orders that have been placed but are not ready, grouped by bill. 
- Advanced: Include the table number(s) for the bill as a single value (comma-separated table numbers)*/
from bills in Bills
where bills.OrderPlaced != null && bills.OrderReady == null
group bills by bills.BillID 

