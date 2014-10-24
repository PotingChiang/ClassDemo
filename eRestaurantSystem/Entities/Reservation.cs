using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.ComponentModel.DataAnnotations;
#endregion

namespace eRestaurantSystem.Entities
{
    public class Reservation
    {
        [Key]
        public int ReservationID { get; set; }
        public string CustomerName { get; set; }
        public DateTime ReservationDate { get; set; }
        public int NumberinParty { get; set; }
        public string ContactPhone { get; set; }
        public string ReservationStatus { get; set; }
        public string Eventcode { get; set; }

        //navigation
        //pointing to a parent one
        public virtual SpecialEvent SpecialEvent { get; set; }
        //pointing to a collection many
        public virtual ICollection<Bill> Bills { get; set; }
        public virtual ICollection<Table> Tables { get; set; }
    }
}
