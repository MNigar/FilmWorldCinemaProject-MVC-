using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FilmWorldCinemaProject_MVC_.Models.DbModel
{
    public class Hall

    {
        public Hall()
        {
            CinemaHalls = new List<CinemaHall>();

        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }


        public virtual List<CinemaHall> CinemaHalls { get; set; }
    }
}