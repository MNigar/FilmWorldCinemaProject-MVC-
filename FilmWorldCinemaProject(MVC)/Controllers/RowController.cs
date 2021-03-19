﻿using FilmWorldCinemaProject_MVC_.CinemaDb;
using FilmWorldCinemaProject_MVC_.Models.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilmWorldCinemaProject_MVC_.Controllers
{
    public class RowController : Controller
    {
        CinemaContext context = new CinemaContext();
        // GET: Row
        public ActionResult Index()
        {
            var rows = context.Row.ToList();
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
            context.Row.Add(model);
            context.SaveChanges();
            return View("Index");
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