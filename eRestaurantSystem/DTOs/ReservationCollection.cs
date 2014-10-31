using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using eRestaurantSystem.POCOs;
#endregion
namespace eRestaurantSystem.DTOs
{
    public class ReservationCollection
    {
        public string SeatingTime { get; set; }
        public List<ReservationSummary> Reservations { get; set; } //beause we use ToList() in our linq Query
    }
}
