using FilmWorldCinemaProject_MVC_.CinemaDb;
using FilmWorldCinemaProject_MVC_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilmWorldCinemaProject_MVC_.Controllers
{
    public class CountriesController : Controller
    {
        // GET: Countries
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Country model)
        {   using(CinemaContext context=new CinemaContext())
            {
                context.Country.Add(model);
                context.SaveChanges();
            }
            return View();
        }
    }
}