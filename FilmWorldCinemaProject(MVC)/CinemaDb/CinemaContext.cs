using FilmWorldCinemaProject_MVC_.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FilmWorldCinemaProject_MVC_.CinemaDb
{
    public class CinemaContext:DbContext
    {
        public CinemaContext() : base("CinemaDb") { }
        public DbSet<Film> Film { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Janr> Janr { get; set; }
        public DbSet<FilmJanr> FilmJanr { get; set; }
        public DbSet<FilmCountry> FilmCountry { get; set; }
    }
}