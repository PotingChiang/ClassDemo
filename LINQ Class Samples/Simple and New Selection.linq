<Query Kind="Statements">
  <Connection>
    <ID>d8953946-3ef8-431f-826d-785928b80217</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

var results = from anItem in SpecialEvents
select new
{
	anItem.EventCode,
	anItem.Description
};
results.Dump();
var entity = from anItem in SpecialEvents
select anItem;
entity.Dump();
