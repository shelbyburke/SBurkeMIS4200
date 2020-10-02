using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SBurkeMIS4200.Models
{
    public class Car
    {
       [Key]
        public int carId { get; set; }

        [Display(Name = "Make of Car")]
        [Required]
        [StringLength(20)]
        public string make { get; set; }

        [Display(Name = "Model of Car")]
        [Required]
        [StringLength(20)]
        public string model { get; set; }


        [Display(Name = "Year of Car")]
        [Required(ErrorMessage = "Year is required")]
        [Range(1900,2021,ErrorMessage ="Year must be between 1900 and 2021")]
        public int year { get; set; }

        [Display(Name = "Color of Car")]
        [Required]
        [StringLength(20)]
        public string color { get; set; }

        //the next two properties link the car to the salesperson
        public int salespersonId { get; set; }
        public virtual Salesperson Salesperson { get; set; }
       
        
        //the next two properties link the car to the customer
        public int customerCarId { get; set; }
        public virtual CustomerCar CustomerCar { get; set; }


    }
}