using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurantSystem.POCOs //POCO only has flappies
{
    public class ReservationSummary
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public string Event { get; set; }
        public int NumberInParty { get; set; }
        public string Contact { get; set; }
    }
}
