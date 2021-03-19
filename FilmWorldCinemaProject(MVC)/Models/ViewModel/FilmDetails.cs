using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmWorldCinemaProject_MVC_.Models
{
    public class FilmDetails
    {
        public List<FilmCountry> FilmCountry { get; set; }
        public List<FilmJanr> FilmJanr { get; set; }
        public Film Films { get; set; }
    }
}