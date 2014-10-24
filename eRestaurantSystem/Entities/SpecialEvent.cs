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
    public class SpecialEvent
    {
        [Key]
        public string EventCode { get; set;}
        public string Description { get; set;}
        public bool Active { get; set;}

        //navigation
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
