using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AsianFoodProject.Models
{
    public class Order
    {
        public int OrderID { get; set; }

        [DisplayName("Order Date")]
        public DateTime OrderDate { get; set; }

        [DisplayName("Order Price")]
        [Required(ErrorMessage = "price is required")]
        [Range(0, 250, ErrorMessage = "please enter a valid price - until 250")]
        public decimal OrderPrice { get; set; }

        public int FoodID { get; set; }
        public string CustomerID { get; set; }

        public virtual Food Food { get; set; }
        public virtual Customer Customer { get; set; }
    }
}