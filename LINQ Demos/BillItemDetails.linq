<Query Kind="Expression">
  <Connection>
    <ID>f69db0fc-eee8-4c1d-ace3-fe347a652c1b</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

//Select the bill items for a specific bill (in this case, the unpaid bill)
from data in Bills
where data.BillID == 10975 // This would be billID that they ask for
select new //Order()
{
	BillID = data.BillID,
	Items = (from info in data.BillItems
			 select new //OrderItem()
			{
				ItemName = info.Item.Description,
				Price = info.SalePrice,
				Quantity = info.Quantity
			}).ToList()
}