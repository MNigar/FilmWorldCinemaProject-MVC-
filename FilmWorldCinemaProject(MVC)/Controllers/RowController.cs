using FilmWorldCinemaProject_MVC_.CinemaDb;
using FilmWorldCinemaProject_MVC_.Filter;
using FilmWorldCinemaProject_MVC_.Models.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilmWorldCinemaProject_MVC_.Controllers
{
    [Auth]
    public class RowController : Controller
    {
        CinemaContext context = new CinemaContext();
        // GET: Row
        public ActionResult Index()
        {
            var rows = context.Row.ToList();
            return View(rows);
        }
        public ActionResult List()
        {
            var rows = context.Seat.ToList();
            return View(rows);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Row model)
        {
            if (ModelState.IsValid)
            {
                var check = context.Row.Where(x => x.Name == model.Name).FirstOrDefault();
                if (check == null)
                {

                    context.Row.Add(model);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    Session["RowError"] = true;
                    return RedirectToAction("Create");

                }
            }
           
            return RedirectToAction("Create");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = context.Row.Where(x => x.Id == id).FirstOrDefault();

            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Row data)
        {

            var entity = context.Entry(data);
            entity.State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {

            var data = context.Row.Where(x => x.Id == id).FirstOrDefault();
            context.Row.Remove(data);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ListForAddingSeat()
        {   
       
            return View();
        }

        [HttpGet]
        public ActionResult CreateHallCinemaRow(int id)

        {

            //ViewBag.Hall = context.CinemaHall.Where(x=>x.Id==id).Select(x=>x.HallId).ToList();
            ViewBag.Cinemahallid = id;
            ViewBag.Rows = context.Row.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult CreateHallCinemaRow(Seat seat,int row)

        {

            //ViewBag.Hall = context.CinemaHall.Where(x=>x.Id==id).Select(x=>x.HallId).ToList();
            if(!context.Seat.Any( x=>x.CinemaHallId== seat.CinemaHallId && x.RowId==row))
            {

                seat.RowId = row;
                context.Seat.Add(seat);
                context.SaveChanges();
                return RedirectToAction("List");
              
            }
            Session["SeatError"] = true;
            return RedirectToAction("CreateHallCinemaRow");
        }

        [HttpGet]
        public ActionResult EditHallCinemaRow(int id)

        {
            var seat = context.Seat.Where(x => x.Id == id).FirstOrDefault();
            
           
            return View(seat);
        }
        [HttpPost]
        public ActionResult EditHallCinemaRow(Seat seat)

        {

            var entity = context.Entry(seat);
            entity.State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("List");
        }


        public ActionResult DeleteHallCinemaRow(int id)
        {

            var data = context.Seat.Where(x => x.Id == id).FirstOrDefault();
            context.Seat.Remove(data);

            context.SaveChanges();
            return RedirectToAction("List");
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