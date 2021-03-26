using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FilmWorldCinemaProject_MVC_.Models.DbModel
{
    public class Row
    {
        public Row()
        {


            Seats = new List<Seat>();
        }
        public int Id { get; set; }
      
        [Required]

        public string Name { get; set; }
        public virtual List<Seat> Seats { get; set; }

    }
}