<Query Kind="Expression">
  <Connection>
    <ID>f69db0fc-eee8-4c1d-ace3-fe347a652c1b</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

//from row in Bills
//orderby row.BillDate descending
//select row.BillDate

//Among the bills, get the max (largest) row such that I look at or use the row's BillDate
Bills.Max(row => row.BillDate)
