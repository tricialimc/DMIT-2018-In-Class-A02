<Query Kind="Expression">
  <Connection>
    <ID>f69db0fc-eee8-4c1d-ace3-fe347a652c1b</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

from category in MenuCategories
select new
{
	Category = category.Description,
	Items = category.Items.Count()
}