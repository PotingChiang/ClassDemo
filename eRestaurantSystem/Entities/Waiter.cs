using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurantSystem.Entities
{
     public class Waiter
    {
         [Key]
         public int WaiterID { get; set; }
         [Required(ErrorMessage = "First Name is a required field.")]
         [StringLength(25, ErrorMessage = "First name maximum size 25 characters")]
         public string FirstName { get; set; }
         [Required(ErrorMessage = "Last Name is a required field.")]
         [StringLength(35, ErrorMessage = "Last name maximum size 35 characters")]
         public string LastName { get; set; }
         [Required(ErrorMessage = "Phone is a required field.")]
         [StringLength(15, ErrorMessage = "Phone maximum size 15 characters")]
         public string Phone { get; set; }
         [Required(ErrorMessage = "Address is a required field.")]
         [StringLength(30, ErrorMessage = "Address maximum size 30 characters")]
         public string Address { get; set; }
         [Required(ErrorMessage = "Hired Date is a required field.")]
         public DateTime HireDate { get; set; }
         public DateTime? ReleaseDate { get; set; }

         //create the equalient of a ReadOnly property
         [NotMapped]
         public string FullName { get { return string.Format("{0}, {1}", LastName, FirstName); } }

         //Navigation
         public virtual ICollection<Bill> Bills { get; set;}
    }
}
