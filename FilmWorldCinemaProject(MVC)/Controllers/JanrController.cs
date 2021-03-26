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
    public class JanrController : Controller
    {
        CinemaContext context = new CinemaContext();

        // GET: Janr
        public ActionResult Index()
        {
            var list = context.Janr.ToList();
            return View(list);
        }
        [HttpGet]
        public ActionResult Create()
        {   
            return View();
        }
        [HttpPost]
        public ActionResult Create( Janr model)
        {
            using(CinemaContext context=new CinemaContext())
            {
                context.Janr.Add(model);
                context.SaveChanges();
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = context.Janr.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Janr janr)
        {

            var entity = context.Entry(janr);
            entity.State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        
        public ActionResult Delete(int id)
        {

            var data = context.Janr.Where(x => x.Id == id).FirstOrDefault();
            context.Janr.Remove(data);
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