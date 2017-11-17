using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyNew.Models
{
    public class Game
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a game name.")]
        public string Name { get; set; }


        [Display(Name = "Number In Stock")]
        [Range(1, 20)]
        public byte NumberInStock { get; set; }
        public byte NumberAvailable { get; set; }


        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }


        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; private set; } = DateTime.Now;

        public Genre Genre { get; set; }

        [Display(Name = "Genre Type")]
        public int GenreId { get; set; }
    }
}