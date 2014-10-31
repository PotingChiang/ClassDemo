using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurantSystem.DTOs //DTO has properties and collections
{
    public class CategoryMenuItems
    {
        public string Description { get; set; }
        public IEnumerable MenuItems { get; set; }
    }
}
