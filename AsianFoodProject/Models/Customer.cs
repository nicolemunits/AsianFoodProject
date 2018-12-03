using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AsianFoodProject.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }

        [DisplayName("E-mail")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "please enter a valid E-mail")]
        public string UserName { get; set; }


        [DisplayName("First Name")]
        [Required(ErrorMessage = "first name is required")]
        [StringLength(10, ErrorMessage = "max length is 10 characters"), RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "please enter a valid name - only letters")]
        public string FirstName { get; set; }


        [DisplayName("Last Name")]
        [Required(ErrorMessage = "last name is required")]
        [StringLength(10, ErrorMessage = "max length is 10 characters"), RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "please enter a valid name - only letters")]
        public string LastName { get; set; }


        [DisplayName("Phone Number")]
        [Required(ErrorMessage = "phone number is required")]
        [RegularExpression(@"\d{9,10}", ErrorMessage = "please enter a valid phone number - 9 or 10 digits")]
        public string PhoneNumber { get; set; }


        [Required(ErrorMessage = "address is required")]
        [StringLength(35, ErrorMessage = "max length is 35 characters")]
        public string Address { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}