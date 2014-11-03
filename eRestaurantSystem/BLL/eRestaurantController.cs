using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using eRestaurantSystem.Entities;
using eRestaurantSystem.DAL;
using System.ComponentModel;
using eRestaurantSystem.POCOs;
using eRestaurantSystem.DTOs;
#endregion

namespace eRestaurantSystem.BLL
{
    [DataObject]
    public class eRestaurantController
    {
        #region SpecialEvents
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<SpecialEvent> SpecialEvent_List()
        {
            //interfacing with our Context class
            using(eRestaurantContext context = new eRestaurantContext())
            {
                // using Context DbSet to get entity data
                //return context.SpecialEvents.ToList();

                //get a list of instances for entity using LINQ
                var results = from item in context.SpecialEvents
                              select item;
                return results.ToList();

            }
        }
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public SpecialEvent SpecialEventByEventCode(string eventcode)
        {
            using(eRestaurantContext context = new eRestaurantContext())
            {
                return context.SpecialEvents.Find(eventcode);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert,false)]
        public void SpecialEvents_Add(SpecialEvent item)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                SpecialEvent added = null;
                added = context.SpecialEvents.Add(item);
                // commits the add to the database
                // evaluates the annotations (validations) on your entity
                // [Required],[StringLength],[Range],...
                context.SaveChanges();  
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update,false)]
        public void SpecialEvents_Update(SpecialEvent item)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                context.Entry<SpecialEvent>(context.SpecialEvents.Attach(item)).State =System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete,false)]
        public void SpecialEvents_Delete(SpecialEvent item)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                SpecialEvent existing = context.SpecialEvents.Find(item.EventCode);
                context.SpecialEvents.Remove(existing);
                context.SaveChanges();
            }
        }
    #endregion

        #region Reservations
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<DTOs.ReservationCollection> ReservationsByTime(DateTime date)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                var results = from data in context.Reservations
                              where data.ReservationDate.Year == date.Year
                                  && data.ReservationDate.Month == date.Month
                                  && data.ReservationDate.Day == date.Day
                                  //do it separately because date includes time 12:00am as its default
                                  //&& data.ReservationStatus == 'B'                  
                                  //char to string
                                  && data.ReservationStatus == "B" 
                              select new POCOs.ReservationSummary//DTO.className
                              {
                                  Name = data.CustomerName,
                                  Date = data.ReservationDate,
                                  Status = data.ReservationStatus,
                                  //Event = data.SpecialEvents.Description,
                                  Event = data.SpecialEvent.Description,//must match the class property name
                                  //NumberInParty = data.NumberInParty,
                                  NumberInParty = data.NumberinParty,//must match the class property name
                                  Contact = data.ContactPhone
                              };

                //Ex. of using group
                var finalResults = from item in results
                                   orderby item.NumberInParty//must be here, before group 
                                   group item by item.Date.TimeOfDay into itemGroup
                                   select new DTOs.ReservationCollection//DTO.classname
                                   {
                                       //SeatingTime = itemGroup.Key,//to cate "key" as a field
                                       SeatingTime = itemGroup.Key.ToString(),//type of property is string
                                       Reservations = itemGroup.ToList()
                                   };

                return finalResults.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Reservation> Reservation_List()
        {
            //interfacing with our Context class
            using (eRestaurantContext context = new eRestaurantContext())
            {
                return context.Reservations.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<Reservation> ReservationbyEvent(string eventcode)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                return context.Reservations.Where(anItem => anItem.Eventcode == eventcode).ToList();
            }
        }
    #endregion

        #region Waiter
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Waiter> Waiter_List()
        {
            //interfacing with our Context class
            using (eRestaurantContext context = new eRestaurantContext())
            {
                // using Context DbSet to get entity data
                //return context.SpecialEvents.ToList();

                //get a list of instances for entity using LINQ
                var results = from item in context.Waiters
                              orderby item.LastName, item.FirstName
                              select item;
                return results.ToList();

            }
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public Waiter GetWaiter(int waiterid)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                return context.Waiters.Find(waiterid);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert, false)]
        public void Waiter_Add(Waiter item)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                Waiter added = null;
                added = context.Waiters.Add(item);
                // commits the add to the database
                // evaluates the annotations (validations) on your entity
                // [Required],[StringLength],[Range],...
                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update, false)]
        public void Waiter_Update(Waiter item)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                context.Entry<Waiter>(context.Waiters.Attach(item)).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public void Waiter_Delete(Waiter item)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                Waiter existing = context.Waiters.Find(item.WaiterID);
                context.Waiters.Remove(existing);
                context.SaveChanges();
            }
        }
        #endregion
        #region Reports
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<POCOs.CategoryMenuItems> GetReportCategoryMenuItems()
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                var results = from data in context.Items
                              select new POCOs.CategoryMenuItems
                              {
                                  CategoryDescription = data.MenuCategory.Description,
                                  ItemDescription = data.Description,
                                  Price = data.CurrentPrice,
                                  Calories = data.Calories,
                                  Comment = data.Comment
                              };
                return results.ToList();
            }
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<POCOs.TotalItemSalesByMenuCategory> TotalItemSalesByMenuCategory()
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                var results = from data in context.Items
                              orderby data.MenuCategory.Description,
                                      data.Description
                              select new POCOs.TotalItemSalesByMenuCategory
                              {
                                  CatDescription = data.MenuCategory.Description,
                                  ItemDescription = data.Description,
                                  Quantity = data.BillItems.Sum(x => x.Quantity),
                                  Price = data.BillItems.Sum(x => x.SalePrice * x.Quantity),
                                  Cost = data.BillItems.Sum(x => x.UnitCost * x.Quantity)
                              };
                return results.ToList();
            }
        }
        #endregion
        #region Linq Queries
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<DTOs.CategoryMenuItems> GetCategoryMenuItems()
        {
            using(eRestaurantContext context = new eRestaurantContext())
            {
                var results = from cat in context.MenuCategories
                              orderby cat.Description
                              select new DTOs.CategoryMenuItems()
                              {
                                  Description = cat.Description,
                                  MenuItems = from item in cat.Items
                                              where item.Active
                                              select new MenuItem()
                                              {
                                                  Description = item.Description,
                                                  Price = item.CurrentPrice,
                                                  Calories = item.Calories,
                                                  Comment = item.Comment
                                              }
                              };

                return results.ToList(); // this was .Dump() in Linqpad
            }
        }

    #endregion

        #region UX Clockpicker
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public DateTime GetLastBillDateTime()
        {
            using (var context = new eRestaurantContext())
            {
                var results = context.Bills.Max(x => x.BillDate);

                return results;
            }
        }
        #endregion
    }

}
