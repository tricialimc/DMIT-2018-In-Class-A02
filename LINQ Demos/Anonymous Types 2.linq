<Query Kind="Expression">
  <Connection>
    <ID>f69db0fc-eee8-4c1d-ace3-fe347a652c1b</ID>
    <Server>.</Server>
    <Database>eRestaurant</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

//Anonymous Types 2
from person in Waiters
where person.ReleaseDate == null	//People still employees
select new
{
	Name = person.FirstName + " " + person.LastName,
	Phone = person.Phone,
	DaysEmployed = (DateTime.Today - person.HireDate).Days
}