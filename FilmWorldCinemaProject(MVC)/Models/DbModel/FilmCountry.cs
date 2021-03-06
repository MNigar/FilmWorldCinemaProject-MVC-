using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmWorldCinemaProject_MVC_.Models
{
    public class FilmCountry
    {
        public int Id { get; set; }
        public int FilmId { get; set; }
        public int CountryId { get; set; }
        public virtual Country Countries { get; set; }
        public virtual Film Films { get; set; }
    }
}