<Query Kind="Statements">
  <Connection>
    <ID>cdd8df40-124a-4036-b06d-57d99ffd316a</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

//use sql to do the heavy lifting because it is designed to such aggregrates in an optimized fashion
//consider we are reporting on items with aggregates of detail billing data
//category description is a single access to a parent.
//
// where data.BillItems.Where( bi=> bi.Bill.BillDate.Month == 6).Any()
// can be used to get details for a specific month, note nested where
var results = from data in Items
             
                          orderby data.MenuCategory.Description, data.Description
                          select new 
                          {
                             
                              CatDescription = data.MenuCategory.Description,
                              ItemDescription = data.Description,
                              Quantity = data.BillItems.Sum(item=> item.Quantity),
                              Sales = data.BillItems.Sum(item=>item.SalePrice * item.Quantity),
                              CostOfSales = data.BillItems.Sum(item=>item.UnitCost * item.Quantity)
                          };
results.Count().Dump();
results.Dump();
