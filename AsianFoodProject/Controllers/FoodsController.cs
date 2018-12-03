using AsianFoodProject.DAL;
using AsianFoodProject.Models;
using Facebook;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AsianFoodProject.Controllers
{
    public class FoodsController : Controller
    {
        
        private AsianFoodContext db = new AsianFoodContext();

        // GET: Foods
        public ActionResult Index(string FoodName, string FoodPrice, string VegetarianOrNot)
        {
            var foods = db.Foods.Include(f => f.Category);

            var PriceList = new List<string>(); //an empty list
            //generate the list
            PriceList.Add("0-50₪");
            PriceList.Add("51₪-100₪");
            PriceList.Add("101₪-150₪");
            PriceList.Add("151₪-200₪");
            PriceList.Add("201₪-250₪");

            ViewBag.FoodPrice = new SelectList(PriceList); //passing the list to the view


            var VegetarianOrNotList = new List<string>(); //an empty list
            //generate the list
            VegetarianOrNotList.Add("Vegetarian");
            VegetarianOrNotList.Add("Not");

            ViewBag.VegetarianOrNot = new SelectList(VegetarianOrNotList); //passing the list to the view

            if (!String.IsNullOrEmpty(FoodName))
            {
                foods = foods.Where(s => s.FoodName.Contains(FoodName));
            }


            if (!String.IsNullOrEmpty(FoodPrice))
            {
                if (FoodPrice.Equals("0-50₪"))
                    foods = foods.Where(s => s.FoodPrice <= 50);

                if (FoodPrice.Equals("51₪-100₪"))
                    foods = foods.Where(s => s.FoodPrice >= 51 && s.FoodPrice <= 100);

                if (FoodPrice.Equals("101₪-150₪"))
                    foods = foods.Where(s => s.FoodPrice >= 101 && s.FoodPrice <= 150);

                if (FoodPrice.Equals("151₪-200₪"))
                    foods = foods.Where(s => s.FoodPrice >= 151 && s.FoodPrice <= 200);

                if (FoodPrice.Equals("201₪-250₪"))
                    foods = foods.Where(s => s.FoodPrice >= 201 && s.FoodPrice <= 250);
            }

            if (!String.IsNullOrEmpty(VegetarianOrNot))
            {
                if (VegetarianOrNot.Equals("Vegetarian"))
                    foods = foods.Where(s => s.IsVegetarian == true);

                if (VegetarianOrNot.Equals("Not"))
                    foods = foods.Where(s => s.IsVegetarian == false);
            }

            return View(foods);
        }
        public ActionResult Wok(string FoodName, string FoodPrice, string VegetarianOrNot)
        {
            var foods = db.Foods.Include(f => f.Category);
            foods = foods.Where(s => s.Category.CategoryName.Equals("Wok"));

            var PriceList = new List<string>(); //an empty list
            //generate the list
            PriceList.Add("0-50₪");
            PriceList.Add("51₪-100₪");
            PriceList.Add("101₪-150₪");
            PriceList.Add("151₪-200₪");
            PriceList.Add("201₪-250₪");

            ViewBag.FoodPrice = new SelectList(PriceList); //passing the list to the view


            var VegetarianOrNotList = new List<string>(); //an empty list
            //generate the list
            VegetarianOrNotList.Add("Vegetarian");
            VegetarianOrNotList.Add("Not");

            ViewBag.VegetarianOrNot = new SelectList(VegetarianOrNotList); //passing the list to the view

            if (!String.IsNullOrEmpty(FoodName))
            {
                foods = foods.Where(s => s.FoodName.Contains(FoodName));
            }


            if (!String.IsNullOrEmpty(FoodPrice))
            {
                if (FoodPrice.Equals("0-50₪"))
                    foods = foods.Where(s => s.FoodPrice <= 50);

                if (FoodPrice.Equals("51₪-100₪"))
                    foods = foods.Where(s => s.FoodPrice >= 51 && s.FoodPrice <= 100);

                if (FoodPrice.Equals("101₪-150₪"))
                    foods = foods.Where(s => s.FoodPrice >= 101 && s.FoodPrice <= 150);

                if (FoodPrice.Equals("151₪-200₪"))
                    foods = foods.Where(s => s.FoodPrice >= 151 && s.FoodPrice <= 200);

                if (FoodPrice.Equals("201₪-250₪"))
                    foods = foods.Where(s => s.FoodPrice >= 201 && s.FoodPrice <= 250);
            }

            if (!String.IsNullOrEmpty(VegetarianOrNot))
            {
                if (VegetarianOrNot.Equals("Vegetarian"))
                    foods = foods.Where(s => s.IsVegetarian == true);

                if (VegetarianOrNot.Equals("Not"))
                    foods = foods.Where(s => s.IsVegetarian == false);

            }

            return View(foods);
        }
        public ActionResult Sushi(string FoodName, string FoodPrice, string VegetarianOrNot)
        {
            var foods = db.Foods.Include(f => f.Category);
            foods = foods.Where(s => s.Category.CategoryName.Equals("Sushi"));

            var PriceList = new List<string>(); //an empty list
            //generate the list
            PriceList.Add("0-50₪");
            PriceList.Add("51₪-100₪");
            PriceList.Add("101₪-150₪");
            PriceList.Add("151₪-200₪");
            PriceList.Add("201₪-250₪");

            ViewBag.FoodPrice = new SelectList(PriceList); //passing the list to the view


            var VegetarianOrNotList = new List<string>(); //an empty list
            //generate the list
            VegetarianOrNotList.Add("Vegetarian");
            VegetarianOrNotList.Add("Not");

            ViewBag.VegetarianOrNot = new SelectList(VegetarianOrNotList); //passing the list to the view

            if (!String.IsNullOrEmpty(FoodName))
            {
                foods = foods.Where(s => s.FoodName.Contains(FoodName));
            }


            if (!String.IsNullOrEmpty(FoodPrice))
            {
                if (FoodPrice.Equals("0-50₪"))
                    foods = foods.Where(s => s.FoodPrice <= 50);

                if (FoodPrice.Equals("51₪-100₪"))
                    foods = foods.Where(s => s.FoodPrice >= 51 && s.FoodPrice <= 100);

                if (FoodPrice.Equals("101₪-150₪"))
                    foods = foods.Where(s => s.FoodPrice >= 101 && s.FoodPrice <= 150);

                if (FoodPrice.Equals("151₪-200₪"))
                    foods = foods.Where(s => s.FoodPrice >= 151 && s.FoodPrice <= 200);

                if (FoodPrice.Equals("201₪-250₪"))
                    foods = foods.Where(s => s.FoodPrice >= 201 && s.FoodPrice <= 250);
            }

            if (!String.IsNullOrEmpty(VegetarianOrNot))
            {
                if (VegetarianOrNot.Equals("Vegetarian"))
                    foods = foods.Where(s => s.IsVegetarian == true);

                if (VegetarianOrNot.Equals("Not"))
                    foods = foods.Where(s => s.IsVegetarian == false);

            }

            return View(foods);
        }
        public ActionResult Rice(string FoodName, string FoodPrice, string VegetarianOrNot)
        {
            var foods = db.Foods.Include(f => f.Category);
            foods = foods.Where(s => s.Category.CategoryName.Equals("Rice"));

            var PriceList = new List<string>(); //an empty list
            //generate the list
            PriceList.Add("0-50₪");
            PriceList.Add("51₪-100₪");
            PriceList.Add("101₪-150₪");
            PriceList.Add("151₪-200₪");
            PriceList.Add("201₪-250₪");

            ViewBag.FoodPrice = new SelectList(PriceList); //passing the list to the view


            var VegetarianOrNotList = new List<string>(); //an empty list
            //generate the list
            VegetarianOrNotList.Add("Vegetarian");
            VegetarianOrNotList.Add("Not");

            ViewBag.VegetarianOrNot = new SelectList(VegetarianOrNotList); //passing the list to the view

            if (!String.IsNullOrEmpty(FoodName))
            {
                foods = foods.Where(s => s.FoodName.Contains(FoodName));
            }


            if (!String.IsNullOrEmpty(FoodPrice))
            {
                if (FoodPrice.Equals("0-50₪"))
                    foods = foods.Where(s => s.FoodPrice <= 50);

                if (FoodPrice.Equals("51₪-100₪"))
                    foods = foods.Where(s => s.FoodPrice >= 51 && s.FoodPrice <= 100);

                if (FoodPrice.Equals("101₪-150₪"))
                    foods = foods.Where(s => s.FoodPrice >= 101 && s.FoodPrice <= 150);

                if (FoodPrice.Equals("151₪-200₪"))
                    foods = foods.Where(s => s.FoodPrice >= 151 && s.FoodPrice <= 200);

                if (FoodPrice.Equals("201₪-250₪"))
                    foods = foods.Where(s => s.FoodPrice >= 201 && s.FoodPrice <= 250);
            }

            if (!String.IsNullOrEmpty(VegetarianOrNot))
            {
                if (VegetarianOrNot.Equals("Vegetarian"))
                    foods = foods.Where(s => s.IsVegetarian == true);

                if (VegetarianOrNot.Equals("Not"))
                    foods = foods.Where(s => s.IsVegetarian == false);

            }

            return View(foods);
        }

        // GET: Foods/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food food = db.Foods.Find(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            return View(food);
        }

        // GET: Foods/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryID", "CategoryName");
            return View();
        }

        // POST: Foods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FoodID,FoodName,CategoryId,IsVegetarian,FoodPrice,ImageUrl")] Food food)
        {
            if (ModelState.IsValid)
            {
                db.Foods.Add(food);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryID", "CategoryName", food.CategoryId);
            return View(food);
        }
       
        // GET: Foods/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food food = db.Foods.Find(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryID", "CategoryName", food.CategoryId);
            return View(food);
        }

        // POST: Foods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FoodID,FoodName,CategoryId,IsVegetarian,FoodPrice,ImageUrl")] Food food)
        {
            if (ModelState.IsValid)
            {
                db.Entry(food).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryID", "CategoryName", food.CategoryId);
            return View(food);
        }

        // GET: Foods/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food food = db.Foods.Find(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            return View(food);
        }

        // POST: Foods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Food food = db.Foods.Find(id);
            db.Foods.Remove(food);
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
    }
}