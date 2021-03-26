using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FilmWorldCinemaProject_MVC_.Models.DbModel
{
    public class Cinema
    {
        public Cinema()
        {

            CinemaHall = new List<CinemaHall>();
        }
        [Key]
        public int Id { get; set; }
        [Required]

        public string Name { get; set; }
        //public virtual List<Hall> Halls { get; set; }
        public virtual List<CinemaHall> CinemaHall { get; set; }


        //public Hall Hall { get; set; }
        //public virtual List<Hall> Halls { get; set; }
    }
}