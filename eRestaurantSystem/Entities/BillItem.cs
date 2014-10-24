using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurantSystem.Entities
{
    public class BillItem
    {
        [Column(Order = 0), Key]
        public int BillID { get; set; }
        [Column(Order = 1), Key]
        public int ItemID { get; set; }
        [Required(ErrorMessage="Quantity is required.")]
        public int Quantity{get;set;}
        [Required(ErrorMessage = "Sale Price is required.")]
        public decimal SalePrice { get; set; }
        [Required(ErrorMessage = "UnitCost is required.")]
        public decimal UnitCost { get; set; }
        [StringLength(50,ErrorMessage = "Notes is a maximum 50 characters.")]
        public string Notes { get; set; }

        //navigation
        public virtual Bill Bill { get; set; }
        public virtual Item Item { get; set; }
    }
}
