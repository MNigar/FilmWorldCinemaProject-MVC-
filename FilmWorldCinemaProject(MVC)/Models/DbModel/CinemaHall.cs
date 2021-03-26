using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FilmWorldCinemaProject_MVC_.Models.DbModel
{
    public class CinemaHall

    {
        public CinemaHall()
        {

           
            Seats = new List<Seat>();
        }

        [Key]
        public int Id { get; set; }
        public int CinemaId { get; set; }
        public int HallId { get; set; }
        public virtual Cinema Cinemas { get; set; }
        public virtual Hall Halls { get; set; }
        public virtual List<Seat> Seats { get; set; }

    }
}