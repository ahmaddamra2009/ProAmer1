using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProAmer1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProAmer1.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext db;
        public AccountController(AppDbContext _db)
        {
            db = _db;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            var chkUser = db.Users.Where(usr => usr.UserName.Equals(user.UserName) && usr.Password.Equals(user.Password));
            if (chkUser.Any())
            {
                if (chkUser.SingleOrDefault().UserType == "admin")
                {
                    HttpContext.Session.SetString("name", chkUser.SingleOrDefault().FullName);
                    return RedirectToAction("Index","Users",new { area="Administrator"});
                }
                else
                {
                    HttpContext.Session.SetString("name", chkUser.SingleOrDefault().FullName);
                    return RedirectToAction("Index", "Developer", new { area = "Administrator" });
                }

            }
            ViewBag.ErrorMsg = "Invalid user/pass";
            return View(user);
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                user.RegisterDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(user);
        }
    }
}
