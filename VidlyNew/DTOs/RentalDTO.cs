using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VidlyNew.DTOs
{
    public class RentalDTO
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime DateRented { get; set; }
        public DateTime? DateReturned { get; set; }

        public CustomerDTO Customer { get; set; }

        public List<int> MovieIds { get; set; }

        public MovieDTO Movie { get; set; }
    }
}