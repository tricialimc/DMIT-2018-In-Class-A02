<Query Kind="Expression">
  <Connection>
    <ID>b9ec75d7-0e1c-4406-a588-30360442f94f</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

//booking - a variable name
from booking in Reservations
where booking.EventCode.Equals("A")
select booking