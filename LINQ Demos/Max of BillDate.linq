<Query Kind="Program">
  <Connection>
    <ID>f69db0fc-eee8-4c1d-ace3-fe347a652c1b</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

void Main()
{
    // Use a Lambda expression to get the maximum.
    // A lambda is simply a shorthand version of a function call
    // that is ideal for anonymous delegates.
    Bills.Max( x => x.BillDate ).Dump();
    
    // Here is the "longer" version using an actual method name
    // that we pass in to the Max() method.
    // Note that the Max() method is overloaded, therefore we
    // need to specify in the generic identifier of the method
    // which version we are using
    Bills.Max<Bills,DateTime>(GetProperty).Dump();
}
// Define other methods and classes here
private DateTime GetProperty(Bills x)
{
    return x.BillDate;
}