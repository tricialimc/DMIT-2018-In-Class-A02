<Query Kind="Expression">
  <Connection>
    <ID>f69db0fc-eee8-4c1d-ace3-fe347a652c1b</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

(from theBill in BillItems
where theBill.BillID == 104
select theBill.SalePrice * theBill.Quantity)