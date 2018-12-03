using AsianFoodProject.DAL;
using AsianFoodProject.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AsianFoodProject.Controllers
{
    public class OrdersController : Controller
    {
        private AsianFoodContext db = new AsianFoodContext();
        private ApplicationDbContext u_db = new ApplicationDbContext();

        // GET: Orders
        public ActionResult Index(DateTime? OrderDate, string UserName, string FoodName)
        {

            var orders = db.Orders.Include(o => o.Customer).Include(o => o.Food);
            if (!(String.IsNullOrEmpty(OrderDate.ToString())))
            {
                orders = orders.Where(x => DbFunctions.TruncateTime(x.OrderDate) == OrderDate.Value);
            }

            if (!(String.IsNullOrEmpty(UserName)))
            {
                orders = orders.Where(k => k.Customer.UserName == UserName);
            }

            if ((!String.IsNullOrEmpty(FoodName)))
            {
                orders = orders.Where(m => m.Food.FoodName == FoodName);
            }

            return View(orders);
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var orders = db.Orders.Include(o => o.Customer).Include(o => o.Food);
            var Order = new List<Order>();
            Order = orders.ToList();
            Order order = Order.Find(item => item.OrderID == id);

            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "UserName");
            ViewBag.FoodID = new SelectList(db.Foods, "FoodID", "FoodName");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderID,OrderDate,OrderPrice,FoodID,CustomerID")] Order order)
        {
            bool flag = true;
            if (order.CustomerID == null)
            {
                ViewBag.CustomerIdError = "You cant make an order without specifying a customer id";
                flag = false;
            }
            if (order.FoodID == 0)
            {
                flag = false;
                ViewBag.FoodError = "You cant make an order without specifying a food";
            }

            if (ModelState.IsValid && flag)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "UserName", order.CustomerID);
            ViewBag.FoodID = new SelectList(db.Foods, "FoodID", "Name", order.FoodID);
            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "UserName", order.CustomerID);
            ViewBag.FoodID = new SelectList(db.Foods, "FoodID", "FoodName", order.FoodID);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,OrderDate,OrderPrice,FoodID,CustomerID")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "UserName", order.CustomerID);
            ViewBag.FoodID = new SelectList(db.Foods, "FoodID", "FoodName", order.FoodID);
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Recipt(int id)
        {
            var food = db.Foods.Include(f => f.Category).First(f => f.FoodID == id);
            Order order = new Order();
            order.FoodID = food.FoodID;
            order.OrderPrice = food.FoodPrice;
            order.OrderDate = DateTime.Now;
            foreach (var customer in u_db.Users)
                if (customer.UserName.Equals(User.Identity.Name))
                    order.CustomerID = customer.Id;

            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
            }
            ViewBag.NameOfFood = food.FoodName;
            return RedirectToAction("Details", new { id =  order.OrderID});
        }

        public ActionResult ShippingInfo(int id)
        {
            if (User.Identity.Name.Equals(""))
                return RedirectToAction("Login", "Account");

            var userId = User.Identity.GetUserId();

            //Customer customerr = new Customer();
            foreach (var customer in u_db.Users)
                if (customer.UserName.Equals(User.Identity.Name))
                {
                    //customer = customer;
                    ViewBag.FoodId = id;
                    return View(customer);
                }

            return RedirectToAction("Login", "Account");
        }
    }
}