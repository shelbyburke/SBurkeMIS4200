using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;

namespace SBurkeMIS4200.Models
{
    public class OrderDetail
    {
        [Key]
        public int orderDetailID { get; set; }
        public int qtyOrdered { get; set; }
        public decimal price { get; set; }

        //the next two properties link the orderDetail to the Order
        public int orderID { get; set; }
        public virtual Orders Orders { get; set; }


        // the next two properties link the orderDetail to the Product
        public int productID { get; set; }
        public virtual Product Product  { get; set; }
    }
}