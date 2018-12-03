using AsianFoodProject.DAL;
using Facebook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AsianFoodProject.Controllers
{
    public class HomeController : Controller
    {
        
        private AsianFoodContext db = new AsianFoodContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
      
        public ActionResult Statistics()
        {
            return View();
        }
        public ActionResult GraphOfCategories()
        {
            return View();
        }
        public ActionResult GraphOfFoods()
        {
            return View();
        }
        public ActionResult CustomersMap()
        {
            return View();
        }
        public class Result
        {
            public string State { get; set; }
            public int freq { get; set; }
        }
      
        //graph
        public JsonResult categoriesGraph()
        {

            List<Result> numOfFoods = new List<Result>();


            var query = from y in db.Categories
                        join l in db.Foods on y.CategoryID equals l.CategoryId
                        select y;


            //group for the graph
            var group = from x in query
                        group x by x.CategoryName into cat
                        select new
                        {
                            CategoryName = cat.Key,
                            Num = cat.Count()
                        };

            foreach (var item in group)
            {
                Result numFoods = new Result();
                numFoods.State = item.CategoryName;
                numFoods.freq = item.Num;


                numOfFoods.Add(numFoods);
            }

            return Json(numOfFoods, JsonRequestBehavior.AllowGet);
        }
        public JsonResult foodsGraph()
        {
            List<Result> numOfOrders = new List<Result>();
            var query = from y in db.Foods
                        join l in db.Orders on y.FoodID equals l.FoodID
                        select y;

            //group for the graph
            var group = from x in query
                        group x by x.FoodName into cat
                        select new
                        {
                            CategoryName = cat.Key,
                            Num = cat.Count()
                        };

            var query2 = from y in @group
                         where y.Num >= 3
                         select y;

            foreach (var item in query2)
            {
                Result numOrders = new Result();
                numOrders.State = item.CategoryName;
                numOrders.freq = item.Num;


                numOfOrders.Add(numOrders);
            }

            return Json(numOfOrders, JsonRequestBehavior.AllowGet);
        }
        //maps
        public JsonResult getAddresses()
        {
            List<places> address = new List<places>();

            foreach (var item in db.Customers)
            {
                places place = new places();

                if (!String.IsNullOrEmpty(item.Address))
                {
                    place.addr = item.Address;
                    address.Add(place);
                }
            }
            return Json(address, JsonRequestBehavior.AllowGet);
        }
        public class places
        {
            public string addr { get; set; }
        }
    }
}