using FilmWorldCinemaProject_MVC_.Models;
using FilmWorldCinemaProject_MVC_.Models.DbModel;
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
        public DbSet<User> User { get; set; }
        public DbSet<FilmCountry> FilmCountry { get; set; }
        public DbSet<Row> Row { get; set; }
        public DbSet<Cinema> Cinema { get; set; }
        public DbSet<Hall> Hall { get; set; }
        public DbSet<Seat> Seat { get; set; }
    }
}