<Query Kind="Expression">
  <Connection>
    <ID>f69db0fc-eee8-4c1d-ace3-fe347a652c1b</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

//List all menu items that are entrees
//in order from the most to least expensive
from food in Items
where food.MenuCategory.Description == "Entree"
orderby food.CurrentPrice descending
select food