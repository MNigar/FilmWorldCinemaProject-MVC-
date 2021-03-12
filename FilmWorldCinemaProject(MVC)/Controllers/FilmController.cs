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
                FilmDetails filmDetails = new FilmDetails();
                filmDetails.FilmCountry = filmCountry;
                filmDetails.FilmJanr = filmJanr;
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

    }
}