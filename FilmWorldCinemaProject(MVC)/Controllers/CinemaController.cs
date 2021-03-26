using FilmWorldCinemaProject_MVC_.CinemaDb;
using FilmWorldCinemaProject_MVC_.Models.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilmWorldCinemaProject_MVC_.Controllers
{
    public class CinemaController : Controller
    {
        CinemaContext context = new CinemaContext();
        // GET: Cinema
        public ActionResult Index()
        {
            var cinema = context.Cinema.ToList();
            return View(cinema);
        }
       
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Cinema model)
        {
            if (ModelState.IsValid)
            {
                var check = context.Cinema.Where(x => x.Name == model.Name).FirstOrDefault();
                if (check == null)
                {

                    context.Cinema.Add(model);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    Session["CinemaError"] = true;
                    return RedirectToAction("Create");
                }
            }

            return RedirectToAction("Create");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = context.Cinema.Where(x => x.Id == id).FirstOrDefault();

            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Cinema cinema)
        {

            var entity = context.Entry(cinema);
            entity.State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {

            var data = context.Cinema.Where(x => x.Id == id).FirstOrDefault();
            context.Cinema.Remove(data);
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