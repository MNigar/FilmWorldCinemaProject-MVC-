using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmWorldCinemaProject_MVC_.Models
{
    public class Janr
    {
        public Janr()
        {
            FilmJanrs = new List<FilmJanr>();

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<FilmJanr> FilmJanrs { get; set; }
    }
}