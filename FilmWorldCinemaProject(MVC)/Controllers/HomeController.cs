using FilmWorldCinemaProject_MVC_.CinemaDb;
using FilmWorldCinemaProject_MVC_.Models.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace FilmWorldCinemaProject_MVC_.Controllers
{
    public class HomeController : Controller
    {
        CinemaContext context = new CinemaContext();


        // GET: Home
        public ActionResult Index()
        {
            return View("Login");
        }
        public ActionResult Login(User user)
        {
            var check = context.User.Where(u => u.Email == user.Email).FirstOrDefault();
            if (check != null)
            {

              
                if (Crypto.VerifyHashedPassword(check.Password, user.Password))
                {
                    Session["username"] = check.Email;

                    return RedirectToAction("Index", "Film");
                }
               
            }
           
            

                  ViewBag.Error = "Yoxdur";
                return View();
            
               
        }
        [HttpGet]
        public ActionResult Register()
        {


            return View();
        
        }
        [HttpPost]
        public ActionResult Register(User user)
        {
            user.Password = Crypto.HashPassword(user.Password);

            context.User.Add(user);
            context.SaveChanges();

            return View();

        }
    }
}