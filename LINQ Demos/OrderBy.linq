<Query Kind="Expression">
  <Connection>
    <ID>b9ec75d7-0e1c-4406-a588-30360442f94f</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

//food - a variable name
from food in Items
//arrange the description in a descending manner
orderby food.Description descending
select food