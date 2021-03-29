using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FilmWorldCinemaProject_MVC_.Models.DbModel
{
    public class User
    {   [Key]
        
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(8)]
        
        public string Password { get; set; }

    }
}