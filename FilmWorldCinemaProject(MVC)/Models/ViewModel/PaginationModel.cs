using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmWorldCinemaProject_MVC_.Models.ViewModel
{
    public class PaginationModel
    {
        public List<Film> Films { get; set; }
        public int FilmPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int PageCount()
        {
            return Convert.ToInt32(Math.Ceiling(Films.Count() / (double)FilmPerPage));
        }
        public List<Film> PaginatedBlogs()
        {
            int start = (CurrentPage - 1) * FilmPerPage;
            var result= Films.OrderBy(b => b.Id).Skip(start).Take(FilmPerPage).ToList();
            return result;
        }
    }
}