<Query Kind="Expression">
  <Connection>
    <ID>d8953946-3ef8-431f-826d-785928b80217</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

from anItem in Reservations
where anItem.SpecialEvents.EventCode.Equals("S") &&
((DateTime.Today.AddDays(-30) < anItem.ReservationDate) &&
(DateTime.Today.AddDays(-23) > anItem.ReservationDate))
orderby anItem.NumberInParty, anItem.CustomerName descending
select new
{	anItem.NumberInParty,
	anItem.CustomerName,
	ResDate = string.Format("{0:MMM dd, yyyy}",anItem.ReservationDate),
	anItem.SpecialEvents.Description
}

