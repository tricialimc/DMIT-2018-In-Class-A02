<Query Kind="Expression">
  <Connection>
    <ID>f69db0fc-eee8-4c1d-ace3-fe347a652c1b</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

//list all menu items that are entrees or beverages
//in order from the most to least expensive
//group the menu items by the menu category id
from food in Items

where food.MenuCategory.Description == "Entree"	
|| food.MenuCategory.Description == "Beverage"
	
orderby food.CurrentPrice descending

group food by food.MenuCategoryID into result

select result