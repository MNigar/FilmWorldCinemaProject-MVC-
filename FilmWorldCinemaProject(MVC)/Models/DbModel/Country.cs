using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FilmWorldCinemaProject_MVC_.Models
{
    public class Country
    {
        public Country()
        {

            FilmCountries = new List<FilmCountry>();
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<FilmCountry> FilmCountries { get; set; }
    }
}