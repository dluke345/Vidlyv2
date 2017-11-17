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
    public class GenresController : ApiController
    {
        private ApplicationDbContext _context;

        public GenresController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/genres
        public IHttpActionResult GetGenres()
        {
            var genresQuery = _context.Genres;

            var genresDtos = genresQuery
                .ToList()
                .Select(Mapper.Map<Genre, GenreTypeDTO>);

            return Ok(genresDtos);
        }

        // GET /api/genres/1
        public IHttpActionResult GetGenre(int id)
        {
            var genre = _context.Genres.SingleOrDefault(c => c.Id == id);

            if (genre == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Genre, GenreTypeDTO>(genre));
        }

        // POST /api/genres
        [Authorize(Roles = RoleName.CanManageMovies)]
        [HttpPost]
        public IHttpActionResult CreateGenre(GenreTypeDTO genreDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var genre = Mapper.Map<GenreTypeDTO, Genre>(genreDto);
            _context.Genres.Add(genre);
            _context.SaveChanges();

            genreDto.Id = genre.Id;

            return Created(new Uri(Request.RequestUri + "/" + genre.Id), genreDto);
        }

        // PUT /api/genres/1
        [Authorize(Roles = RoleName.CanManageMovies)]
        [HttpPut]
        public void UpdateGenre(int id, GenreTypeDTO genreDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var genreInDb = _context.Genres.SingleOrDefault(c => c.Id == id);

            if (genreInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(genreDto, genreInDb);

            _context.SaveChanges();
        }

        // DELETE /api/genres/1
        [Authorize(Roles = RoleName.CanManageMovies)]
        [HttpDelete]
        public void DeleteGenre(int id)
        {
            var genreInDb = _context.Genres.SingleOrDefault(c => c.Id == id);

            if (genreInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Genres.Remove(genreInDb);
            _context.SaveChanges();
        }

    }
}
