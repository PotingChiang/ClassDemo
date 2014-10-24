using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurantSystem.Entities
{
    public class Item
    {
        [Key]
        public Int32 ItemID { get;set;}
        [Required(ErrorMessage="Description is required.")]
        [StringLength(35,ErrorMessage="Description has a maximum 35 characters")]
        public string Description { get;set;}
        [Required(ErrorMessage="Current Price is required")]
        public decimal CurrentPrice { get;set;}
        [Required(ErrorMessage="Current cost is required")]
        public decimal CurrentCost { get;set;}
        public bool Active { get;set;}
        public Int32? Calories { get;set;}
        [StringLength(50,ErrorMessage="Comment has a maximum 50 characters")]
        public string Comment { get;set;}
        [Required(ErrorMessage="Menu category is required.")]
        public Int32 MenuCategoryID { get;set;}

        //navigation
        public virtual MenuCategory MenuCategory { get;set;}
        public virtual ICollection<BillItem> BillItems { get; set; }
    }
}
