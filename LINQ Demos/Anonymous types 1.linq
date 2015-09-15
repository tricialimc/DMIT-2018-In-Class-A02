<Query Kind="Expression">
  <Connection>
    <ID>f69db0fc-eee8-4c1d-ace3-fe347a652c1b</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

//Anonymous Types
from food in Items
where food.MenuCategory.Description == "Entree" 
	&& food.Active
orderby food.CurrentPrice descending
select new 
{
	Description = food.Description,
	Price = food.CurrentPrice,
	Calories = food.Calories
}