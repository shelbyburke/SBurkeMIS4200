using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SBurkeMIS4200.Models
{
    public class Salesperson
    {
        [Key]
        public int salespersonId { get; set; }


        [Display(Name = "Salesperson First Name")]
        [Required(ErrorMessage = "Student first name is required")]
        [StringLength(20)]
        public string salespersonFirstName { get; set; }


        [Display(Name = "Last Name")]
        [Required]
        [StringLength(20)]
        public string salespersonLastName { get; set; }


        [Display(Name = "Most used email address")]
        [Required]
        [EmailAddress(ErrorMessage = "Enter your most frequently used email address")]
        public string email { get; set; }

        [Display(Name = "Salesperson Phone")]
        [RegularExpression(@"^(\(\d{3}\) |\d{3}-)\d{3}-\d{4}$",
            ErrorMessage = "Phone numbers must be in the format (xxx) xxx-xxxx or xxx-xxx-xxxx")]
        public string salespersonPhone { get; set; }

        [Display(Name = "Address (i.e., '488 Main Street, Athens, OH 45701)")]
        [Required]
        [StringLength(200)]
        public string salespersonAddress { get; set; }
        public ICollection<Car> Car { get; set; }

        public string salespersonFullName { get { return salespersonLastName + ", " + salespersonFirstName; } }
    }
}