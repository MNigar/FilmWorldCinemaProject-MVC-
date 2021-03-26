using FilmWorldCinemaProject_MVC_.CinemaDb;
using FilmWorldCinemaProject_MVC_.Models;
using FilmWorldCinemaProject_MVC_.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilmWorldCinemaProject_MVC_.Controllers
{
    public class FilmController : Controller
    {
        CinemaContext context = new CinemaContext();
        public ActionResult Index(int page = 1)
        {
            using (CinemaContext context=new  CinemaContext())
            {
                var filmList=context.Film.OrderBy(x=>x.PublicationDate).ToList();
                //ViewBag.Films = filmList;
                //var filmJanrList = context.FilmJanr.ToList();
                var viewModel = new PaginationModel()
                {
                    FilmPerPage = 7,
                    Films = filmList,
                    CurrentPage = page
                };

                return View(viewModel);
            }
          

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            using (CinemaContext context = new CinemaContext())
            {
                FilmList list = new FilmList();
                list.Films= context.Film.OrderByDescending(x => x.Id).Take(10).ToList();
                list.Janrs = context.Janr.ToList();
                list.Countries = context.Country.ToList();

                return View(list);

            }
              
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(FilmList model, CountryJanrListModel listModel)
       {
            using (CinemaContext context = new CinemaContext())
            {
                context.Film.Add(model.Film);
                context.SaveChanges();

                var filmCountries = new FilmCountry();
                if (listModel.Countries == null || listModel.Janrs == null)
                {
                    ViewBag.ErrorMessage = "Daxil edin";
                }
                else
                {
                    foreach (var item in listModel.Countries)
                    {
                        filmCountries.CountryId = item;
                        filmCountries.FilmId = model.Film.Id;
                        context.FilmCountry.Add(filmCountries);
                        context.SaveChanges();
                    }


                    var filmJanr = new FilmJanr();
                    foreach (var item in listModel.Janrs)
                    {
                        filmJanr.JanrId = item;
                        filmJanr.FilmId = model.Film.Id;
                        context.FilmJanr.Add(filmJanr);
                        context.SaveChanges();
                    }
                }
                return Redirect("Create");
            }            
        }  

        public ActionResult Details(int id)
        {
            ViewBag.Message = "Your contact page.";
            using (CinemaContext context = new CinemaContext())
            {
                var filmJanr = context.FilmJanr.Include("Films").Include("Janrs").Where(filmJ => filmJ.FilmId == id).ToList();
                var filmCountry= context.FilmCountry.Include("Films").Include("Countries").Where(filmC => filmC.FilmId == id).ToList();
                var films = context.Film.Where(x => x.Id == id).FirstOrDefault();
                FilmDetails filmDetails = new FilmDetails();
                filmDetails.FilmCountry = filmCountry;
                filmDetails.FilmJanr = filmJanr;
                filmDetails.Films = films;
                return View(filmDetails);
            }              
        }

        [HttpGet]
        public ActionResult Search(DateTime? startDate, DateTime? endDate)
        {
            using (CinemaContext context = new CinemaContext())
            {
                DateTime defaultStart = new DateTime(01, 01, 0001);
                var startDateWithHours = startDate?.Date==null? defaultStart : startDate?.Date;
                var endDateWithHours = endDate?.Date == null ? DateTime.Now.Date : endDate?.Date;
                var result = context.Film.Where(x => DbFunctions.TruncateTime(x.PublicationDate) >= startDateWithHours && DbFunctions.TruncateTime(x.PublicationDate) <= endDateWithHours).ToList();              
                return View(result);
            }

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            //var filmJanr = context.FilmJanr.Include("Films").Include("Janrs").ToList();
            //var filmCountry = context.FilmCountry.Include("Films").Include("Countries").ToList();
            var film = context.Film.Where(x => x.Id == id).FirstOrDefault();
            ViewBag.Janrs = context.Janr.ToList();
            ViewBag.Countries = context.Country.ToList();

            //FilmDetails filmDetails = new FilmDetails();
            //filmDetails.FilmCountry = filmCountry;
            //filmDetails.FilmJanr = filmJanr;
            //filmDetails.Films = films;

            return View(film);
        }
        [HttpPost]
        public ActionResult Edit(Film film,int[] Countries,int[] Janrs)
        {

            var entity = context.Entry(film);
            entity.State = System.Data.Entity.EntityState.Modified;

            context.SaveChanges();
            DeleteRelationShip(film);

            foreach (var i in Countries)
            {
                FilmCountry filmCountry = new FilmCountry();
                filmCountry.FilmId = film.Id;
                filmCountry.CountryId = i;
                context.FilmCountry.Add(filmCountry);
                
                context.SaveChanges();
            }
            foreach (var i in Janrs)
            {
                FilmJanr janr = new FilmJanr();

                janr.FilmId = film.Id;
                janr.JanrId = i;
                context.FilmJanr.Add(janr);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {

            var data = context.Film.Where(x => x.Id == id).FirstOrDefault();
            context.Film.Remove(data);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        private void DeleteRelationShip(Film film)
        {
            var countryList = context.FilmCountry.Where(c => c.FilmId == film.Id).ToList();
            var janrList = context.FilmJanr.Where(c => c.FilmId == film.Id).ToList();

            foreach (FilmCountry item in countryList)
            {
                context.FilmCountry.Remove(item);

            }
            foreach (FilmJanr item in janrList)
            {
                context.FilmJanr.Remove(item);

            }
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