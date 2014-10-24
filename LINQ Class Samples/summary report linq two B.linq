<Query Kind="Statements">
  <Connection>
    <ID>e411662b-46e6-4089-a965-14f5fb300883</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

var results = from data in BillItems
				//once group is used then details are aggregrates 
				//orderby data.Item.MenuCategory.Description, data.Item.Description
              group data by new {cat = data.Item.MenuCategory.Description, dd= data.Item.Description} into g
             
              select new 
              {
                              
                   CatDescription = g.Key.cat, //data.Item.MenuCategory.Description,
                   ItemDescription = g.Key.dd, //data.Item.Description
                   Quantity = g.Sum( x=> x.Quantity),
                   Sales = g.Sum(x=> x.SalePrice * x.Quantity),
                   CostOfSales = g.Sum(x=> x.UnitCost * x.Quantity),
               };
results.Count().Dump();
results.Dump();