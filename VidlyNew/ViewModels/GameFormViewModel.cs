using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VidlyNew.Models;

namespace VidlyNew.ViewModels
{
    public class GameFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }


        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a game name.")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Number In Stock")]
        [Range(1, 20)]
        public byte? NumberInStock { get; set; }

        [Display(Name = "Number Available")]
        [Range(0, 20)]
        public byte? NumberAvailable { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; private set; } = DateTime.Now;


        [Display(Name = "Genre Type")]
        public int GenreId { get; set; }

        public GameFormViewModel()
        {
            Id = 0;
        }

        public GameFormViewModel(Game game)
        {
            Id = game.Id;
            Name = game.Name;
            ReleaseDate = game.ReleaseDate;
            NumberInStock = game.NumberInStock;
            GenreId = game.GenreId;
        }
    }
}