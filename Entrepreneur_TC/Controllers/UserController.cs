using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entrepreneur_TC.Models;
using Entrepreneur_TC.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Entrepreneur_TC.Controllers
{
    public class UserController : Controller
    {
        // GET: /<controller>/
        public ActionResult Index()
        {
            using (UserContext user = new UserContext())
            {
                return View(user.user.ToList());
            }
        }


        public ActionResult Register()
        {
            return View();
        }


        // Register
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                using (UserContext db = new UserContext())
                {
                    db.user.Add(user);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = user.firstName + " " + user.lastName + " successfully registered.";
            }
            return View();
        }


        // Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            using (UserContext db = new UserContext())
            {
                var usr = db.user.Single(u => u.Username == user.Username && u.Password == user.Password);
                if (usr != null)
                {
                    HttpContext.Session.SetString("UserID", usr.UserID.ToString());
                    HttpContext.Session.SetString("Username", usr.Username.ToString());
                    return RedirectToAction("LoggedIn");
                } 
                else
                {
                    ModelState.AddModelError("", "Username or Password incorrect.");
                }
            }
            return View();
        }


        // Logged In View
        public ActionResult LoggedIn()
        {
            if (HttpContext.Session.Get("UserId") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}
