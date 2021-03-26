using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        public string Name { get; set; }
        [Required]

        public DateTime PublicationDate { get; set; }
        [Required]
        public string Link { get; set; }
        [Required]
        public string Duration { get; set; }
   
        public virtual List<FilmCountry> FilmCountries { get; set; }
    
        public virtual List<FilmJanr> FilmJanrs { get; set; }

    }
}