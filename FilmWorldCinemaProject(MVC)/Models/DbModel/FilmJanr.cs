using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmWorldCinemaProject_MVC_.Models
{
    public class FilmJanr
    {
        public int Id { get; set; }
        public int FilmId { get; set; }
        public int JanrId { get; set; }
        public virtual Janr Janrs { get; set; }
        public virtual Film Films { get; set; }
    }
}