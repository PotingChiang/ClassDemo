using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurantSystem.Entities
{
    public class Bill
    {
        [Key]
        public int BillID { get; set; }
        [Required(ErrorMessage = "Bill Date is required.")]
        public DateTime BillDate { get; set; }
        public TimeSpan OrderPlaced { get; set; }
        public TimeSpan OrderReady { get; set; }
        public TimeSpan OrderServed { get; set; }
        public TimeSpan OrderPaid { get; set; }
        [Required(ErrorMessage = "Number in party is required.")]
        public int NumberInParty { get; set; }
        public bool PaidStatus { get; set; }
        [Required(ErrorMessage = "Waiter is required.")]
        public int WaiterID { get; set; }
        public int? TableID { get; set; }
        public int? ReservationID { get; set; }
        [StringLength(50,ErrorMessage="Comment has a max size of 50 characters")]
        public string Comment { get; set; }

        //navigation
        public virtual Waiter Waiter { get; set; }
        public virtual Reservation Reservation { get; set; }
        public virtual Table Table { get; set; }
        public virtual ICollection<BillItem> BillItems { get; set; }
    }
}
