using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmWorldCinemaProject_MVC_.Models.DbModel
{
    public class Seat
    {
        public int Id { get; set; }
        public int CinemaHallId { get; set; }
        public int RowId { get; set; }
        public int Count { get; set; }
        public virtual Row Row { get; set; }
        public virtual CinemaHall CinemaHall{get; set;}
     

    }
}