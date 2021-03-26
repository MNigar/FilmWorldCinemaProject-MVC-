using FilmWorldCinemaProject_MVC_.CinemaDb;
using FilmWorldCinemaProject_MVC_.Filter;
using FilmWorldCinemaProject_MVC_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilmWorldCinemaProject_MVC_.Controllers
{
    [Auth]
    public class CountriesController : Controller
    {
        CinemaContext context = new CinemaContext();
        // GET: Countries
        public ActionResult Index()
        {
            var list = context.Country.ToList();
            return View(list);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Country model)
        {   
                context.Country.Add(model);
                context.SaveChanges();
            
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = context.Country.Where(x => x.Id == id).FirstOrDefault();

            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Country country)
        {

            var entity = context.Entry(country);
            entity.State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {

            var data = context.Country.Where(x => x.Id == id).FirstOrDefault();
            context.Country.Remove(data);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}