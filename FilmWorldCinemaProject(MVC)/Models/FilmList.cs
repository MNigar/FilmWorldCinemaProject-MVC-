using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmWorldCinemaProject_MVC_.Models
{
    public class FilmList
    {
        public List<Film> Films { get; set; }
        public List<Country> Countries { get; set; }
        public List<Janr> Janrs { get; set; }
        public Film Film { get; set; }
    }
}