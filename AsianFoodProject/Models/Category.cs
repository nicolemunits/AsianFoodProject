using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AsianFoodProject.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public virtual Category Categories { get; set; }
        public virtual ICollection<Food> Foods { get; set; }
    }
}
