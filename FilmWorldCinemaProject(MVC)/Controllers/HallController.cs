using FilmWorldCinemaProject_MVC_.CinemaDb;
using FilmWorldCinemaProject_MVC_.Filter;
using FilmWorldCinemaProject_MVC_.Models.DbModel;
using FilmWorldCinemaProject_MVC_.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilmWorldCinemaProject_MVC_.Controllers
{   [Auth]
    public class HallController : Controller
    {
        // GET: Hall
        CinemaContext context = new CinemaContext();

        public ActionResult Index()
        {
            var list = context.Hall.ToList();
            return View(list);
        }
        public ActionResult HallCinemaList()
        {
            var list = context.CinemaHall.ToList();
            List<int> colums = new List<int>();
            //foreach (var i in list)
            //{ 
            //    var seat = context.Seat.Where(x => x.CinemaHallId == i.Id).FirstOrDefault();
            //    if (seat != null)
            //    colums.Add(seat.CinemaHallId);
            //}
            //ViewBag.Seat = colums;
            return View(list);
        }
        [HttpGet]
        public ActionResult Create()
        
        
        {
            ViewBag.Cinema = context.Cinema.ToList();
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(Hall model)
        {
            if (ModelState.IsValid)
            {
                var check = context.Hall.Where(x => x.Name == model.Name).FirstOrDefault();
                if (check == null)
                {

                    context.Hall.Add(model);

                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    Session["HallError"] = true;
                    return RedirectToAction("Create");
                }
            }
            return RedirectToAction("Create");


        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = context.Hall.Where(x => x.Id == id).FirstOrDefault();

            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Hall data)
        {

            var entity = context.Entry(data);
            entity.State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {

            var data = context.Hall.Where(x => x.Id == id).FirstOrDefault();
            context.Hall.Remove(data);
            context.SaveChanges();
            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult CreateHallCinema()
        
        {
            ViewBag.Cinema = context.Cinema.ToList();
            ViewBag.Hall = context.Hall.ToList();

            return View();
        }
        [HttpPost]
        public ActionResult CreateHallCinema( int[] halls,int cinema )
        {
            if (ModelState.IsValid)
            {
                CinemaHall cinemaHall = new CinemaHall();
                foreach (var i in halls)
                {
                    cinemaHall.CinemaId = cinema;
                    cinemaHall.HallId = i;
                    var check = context.CinemaHall.Where(x => x.CinemaId == cinemaHall.CinemaId && x.HallId == cinemaHall.HallId).FirstOrDefault();
                    if (check == null)
                    {
                        context.CinemaHall.Add(cinemaHall);
                        context.SaveChanges();
                    }
                    else
                    {
                        Session["CinemaHallError"] = true;
                        return RedirectToAction("CreateHallCinema");
                    }

                }
                            return RedirectToAction("HallCinemaList");

            }
            return RedirectToAction("HallCinemaList");
        }
        [HttpGet]
        public ActionResult EditHallCinema(int id)

        {
            var list = context.CinemaHall.Where(x => x.Id == id).FirstOrDefault();
            ViewBag.Hall = context.Hall.ToList();
            //ViewBag.selectedHall = list.Halls.Name;
            return View(list);
        }
        [HttpPost]
        public ActionResult EditHallCinema(CinemaHall model,int halls)
        {

            model.HallId = halls;
            var entity = context.Entry(model);
            entity.State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("HallCinemaList");
        }

        public ActionResult DeleteHallCinema(int id)
        {

            var data = context.CinemaHall.Where(x => x.Id == id).FirstOrDefault();
            context.CinemaHall.Remove(data);

            context.SaveChanges();
            return RedirectToAction("HallCinemaList");
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