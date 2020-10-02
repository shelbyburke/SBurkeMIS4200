using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SBurkeMIS4200.Models
{
    public class Orders
    {
        [Key]
        public int orderID { get; set; }
        public string description { get; set; }
        public DateTime orderDate { get; set; }
        public ICollection<OrderDetail> OrderDetail { get; set; }

        // order is on the "one" side of a one-to-many relationship with OrderDetail
        // and we indivcate that with an ICollection
        // order is on the many side of the one-to-many relationship between Customer

        public int  customerId { get; set; }
        public virtual Customer Customer { get; set; }



    }
}