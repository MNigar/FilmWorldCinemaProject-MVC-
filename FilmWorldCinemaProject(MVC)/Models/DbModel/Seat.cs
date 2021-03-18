using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmWorldCinemaProject_MVC_.Models.DbModel
{
    public class Seat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HallId { get; set; }
        public int RowId { get; set; }
        public int Count { get; set; }
        public Row Row { get; set; }
        public Hall Hall{get; set;}


    }
}