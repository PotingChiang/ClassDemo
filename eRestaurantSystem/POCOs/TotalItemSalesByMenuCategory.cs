using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurantSystem.POCOs
{
    public class TotalItemSalesByMenuCategory
    {
        public string CatDescription { get; set; }
        public string ItemDescription { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
    }
}
