<Query Kind="Statements">
  <Connection>
    <ID>e411662b-46e6-4089-a965-14f5fb300883</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

var results = from item in BillItems
orderby item.Item.MenuCategory.Description, item.Item.Description
select new
{
	CatDescription = item.Item.MenuCategory.Description,
	ItemDescription = item.Item.Description,
	Quantity = item.Quantity,
	Price = item.SalePrice * item.Quantity,
	Cost = item.UnitCost * item.Quantity
};
results.Count().Dump();
results.Dump();