using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SBurkeMIS4200.Models
{
    public class CustomerCar
    {
        [Key]
        public int customerCarId { get; set; }
        [Display(Name = "Customer First Name")]
        [Required(ErrorMessage = "Customer first name is required")]
        [StringLength(20)]
        public string customerCarFirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Customer last name is required")]
        [StringLength(20)]
        public string customerCarLastName { get; set; }
        [Display(Name = "Phone")]
        [RegularExpression(@"^(\(\d{3}\) |\d{3}-)\d{3}-\d{4}$",
            ErrorMessage = "Phone numbers must be in the format (xxx) xxx-xxxx or xxx-xxx-xxxx")]
        public string customerCarPhone { get; set; }
        [Display(Name = "Address (i.e., '231 Court Street, Athens, OH 45701)")]
        [Required]
        [StringLength(200)]
        public string address { get; set; }

        public ICollection<Car> Car { get; set; }
        public string customerFullName { get { return customerCarLastName + ", " + customerCarFirstName; } }
    }
}