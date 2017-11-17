using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VidlyNew.Models;

namespace VidlyNew.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        //Can get rid of this to improve form validation
        //public Movie Movie { get; set; }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Genre Type")]
        [Required]
        public int GenreId { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? MovieReleaseDate { get; set; }

        [Required]
        [Display(Name = "Date Added")]
        public DateTime MovieDateAdded { get; private set; } = DateTime.Now;

        [Required]
        [Display(Name = "Number In Stock")]
        [Range(1, 20)]
        public byte? NumberInStock { get; set; }

        [Display(Name = "Number Available")]
        [Range(0, 20)]
        public byte? NumberAvailable { get; set; }



        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            MovieReleaseDate = movie.MovieReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }
    }
}