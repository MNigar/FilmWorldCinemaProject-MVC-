using System;
using System.Collections.Generic;
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
        public string Name { get; set; }
        public virtual List<Seat> Seats { get; set; }

    }
}