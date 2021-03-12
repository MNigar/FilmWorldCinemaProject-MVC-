using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmWorldCinemaProject_MVC_.Models
{
    public class Film
    {
        public Film()
        {
            FilmJanrs = new List<FilmJanr>();
            FilmCountries = new List<FilmCountry>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Link { get; set; }
        public string Duration { get; set; }
        public List<FilmCountry> FilmCountries { get; set; }
        public List<FilmJanr> FilmJanrs { get; set; }

    }
}