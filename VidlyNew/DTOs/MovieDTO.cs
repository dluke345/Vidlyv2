using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VidlyNew.Models;

namespace VidlyNew.DTOs
{
    public class MovieDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int GenreId { get; set; }

        public GenreTypeDTO Genre { get; set; }

        [Required]
        public DateTime MovieReleaseDate { get; set; }

        [Required]
        public DateTime MovieDateAdded { get; private set; } = DateTime.Now;

        [Required]
        [Range(1, 20)]
        public byte NumberInStock { get; set; }
    }
}