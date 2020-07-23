using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DeliveryCart.Models
{
    public class Deliverymodel
    {
        [DisplayName("Order Id")]
        public string OrderId { get; set; }

        [DisplayName("Order Name")]
        public string OrderName { get; set; }
        [DisplayName("Order Quantity")]
        public string OrderQuantity { get; set; }
        [DisplayName("Email")]
        public string Email{ get; set; }
    }
}