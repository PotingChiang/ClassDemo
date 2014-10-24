<Query Kind="Statements">
  <Connection>
    <ID>cdd8df40-124a-4036-b06d-57d99ffd316a</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

 //grab all the details and pass them to an inefficient software package to 
 //aggregate results.
 var results = from item in BillItems
                          orderby item.Item.MenuCategory.Description,item.Item.Description
                          select new 
                          {
                              
                              CatDescription = item.Item.MenuCategory.Description,
                              ItemDescription = item.Item.Description,
                              Quantity = item.Quantity,
                              Sales = item.SalePrice * item.Quantity,
                              CostOfSales = item.UnitCost * item.Quantity
                          };
results.Count().Dump();
results.Dump();