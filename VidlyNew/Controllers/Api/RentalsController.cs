using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VidlyNew.DTOs;
using VidlyNew.Models;

namespace VidlyNew.Controllers.Api
{
    public class RentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/rentals
        public IEnumerable<RentalDTO> GetRentals()
        {
            var rentalQuery = _context.Rentals
                .ToList()
                .Select(Mapper.Map<Rental, RentalDTO>);
                
                
                



            //var customer = _context.Customers.Single(c => c.Id == rentalDto.CustomerId);

            //var movies = _context.Movies.Where(m => rentalDto.MovieIds.Contains(m.Id)).ToList();





            return rentalQuery;
        }

        //GET /api/rentals/1
        //public IHttpActionResult GetRental(int id)
        //{
        //    var rental = _context.Rentals.SingleOrDefault(c => c.Id == id);

        //    if (rental == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(Mapper.Map<Rental, RentalDTO>(rental));
        //}

        //POST /api/rentals
        [Authorize(Roles = RoleName.CanManageMovies)]
        [HttpPost]
        public IHttpActionResult CreateRentals(RentalDTO rentalDto)
        {
            if (rentalDto.MovieIds.Count == 0)
            {
                return BadRequest("No movie Ids have been given.");
            }

            var customer = _context.Customers.SingleOrDefault(c => c.Id == rentalDto.CustomerId);

            if (customer == null)
            {
                return BadRequest("Customer Id is not valid");
            }

            var movies = _context.Movies.Where(m => rentalDto.MovieIds.Contains(m.Id)).ToList();

            if (movies.Count != rentalDto.MovieIds.Count)
            {
                return BadRequest("One or more MovieIds are invalid.");
            }

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                {
                    return BadRequest("Movie is not available.");
                }

                movie.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();





            //if (!ModelState.IsValid)
            //    return BadRequest();

            //var rental = Mapper.Map<RentalDTO, Rental>(rentalDto);
            //_context.Rentals.Add(rental);
            //_context.SaveChanges();

            //rentalDto.Id = rental.Id;

            //return Created(new Uri(Request.RequestUri + "/" + rental.Id), rentalDto);




        }

        //PUT /api/rentals/1
        //[HttpPut]
        //public void UpdateRental(int id, RentalDTO rentalDto)
        //{
        //    if (!ModelState.IsValid)
        //        throw new HttpResponseException(HttpStatusCode.BadRequest);

        //    var rentalInDb = _context.Rentals.SingleOrDefault(c => c.Id == id);

        //    if (rentalInDb == null)
        //    {
        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    }

        //    Mapper.Map(rentalDto, rentalInDb);

        //    _context.SaveChanges();

        //}


        //DELETE /api/rentals/1
        //[HttpDelete]
        //public void DeleteRental(int id)
        //{
        //    var rentalInDb = _context.Rentals.SingleOrDefault(c => c.Id == id);

        //    if (rentalInDb == null)
        //    {
        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    }

        //    _context.Rentals.Remove(rentalInDb);
        //    _context.SaveChanges();
        //}

    }
}
