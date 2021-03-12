using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        public string Name { get; set; }
        public List<FilmJanr> FilmJanrs { get; set; }
    }
}