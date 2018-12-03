using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AsianFoodProject.Models
{
    public class Food
    {
        public int FoodID { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "food name is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "please enter a valid name - only letters")]
        public string FoodName { get; set; }


        [DisplayName("Category")]
        public int CategoryId { get; set; }

        [DisplayName("Is Vegetarian")]
        public bool IsVegetarian { get; set; }


        [DisplayName("Price")]
        [Required(ErrorMessage = "price is required")]
        [Range(0, 250, ErrorMessage = "please enter a valid price - until 250")]
        public decimal FoodPrice { get; set; }

        [DisplayName("Image Url")]
        public string ImageUrl { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}