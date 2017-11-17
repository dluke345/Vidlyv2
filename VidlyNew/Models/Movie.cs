using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyNew.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        [Display(Name = "Genre Type")]
        [Required]
        public int GenreId { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime MovieReleaseDate { get; set; }

        [Required]
        [Display(Name = "Date Added")]
        public DateTime MovieDateAdded { get; private set; } = DateTime.Now;

        [Required]
        [Display(Name = "Number In Stock")]
        [Range(1, 20)]
        public byte NumberInStock { get; set; }

        public byte NumberAvailable { get; set; }
    }
}