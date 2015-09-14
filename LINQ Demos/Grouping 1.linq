<Query Kind="Expression">
  <Connection>
    <ID>b9ec75d7-0e1c-4406-a588-30360442f94f</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// Grouping sample
from food in Items
group food by food.MenuCategoryID
