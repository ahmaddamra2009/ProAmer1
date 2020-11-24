using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProAmer1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProAmer1.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext db;
        public ProductsController(AppDbContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            ViewBag.myName = HttpContext.Session.GetString("name");
            return View(db.Products.ToList());
        }
        public IActionResult Index2()
        {
            return View(db.Products.ToList());
        }
        public IActionResult Aboutus()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);

        }

        public IActionResult Details(int id)
        {
            // LINQ
            //var data = (from pro in db.Products
            //            where pro.ProductId == id
            //            select pro).SingleOrDefault();
            var data = db.Products.Find(id);
            return View(data);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = db.Products.Find(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {

            if (ModelState.IsValid)
            {
                db.Products.Update(product);
                db.SaveChanges();
             return RedirectToAction(nameof(Index));
             //   return View("Index",db.Products.ToList());
            }
            return View(product);
        }

        public IActionResult Delete(int id)
        {
            Product product = db.Products.Find(id);
            return View(product);
        }

        public IActionResult DeleteConfirmed(Product product)
        {
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
