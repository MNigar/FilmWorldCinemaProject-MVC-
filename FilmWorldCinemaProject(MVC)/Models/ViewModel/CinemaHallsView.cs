using FilmWorldCinemaProject_MVC_.Models.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmWorldCinemaProject_MVC_.Models.ViewModel
{
    public class CinemaHallsView
    {
        public int[] Cinemas { get; set; }
        public int[] Halls { get; set; }

    }
}