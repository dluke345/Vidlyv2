using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VidlyNew.DTOs;
using VidlyNew.Models;
using System.Data.Entity;

namespace VidlyNew.Controllers.Api
{
    public class GamesController : ApiController
    {
        private ApplicationDbContext _context;

        public GamesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/Games
        public IHttpActionResult GetGames(string query = null)
        {
            var GamesQuery = _context.Games
                .Include(m => m.Genre)
                .Where(m => m.NumberAvailable > 0);

            if (!String.IsNullOrWhiteSpace(query))
            {
                GamesQuery = GamesQuery.Where(m => m.Name.Contains(query));
            }

            var gamesDtos = GamesQuery
                .ToList()
                .Select(Mapper.Map<Game, GameDTO>);

            return Ok(gamesDtos);
        }


        // GET /api/Games/1
        public IHttpActionResult GetGame(int id)
        {
            var Game = _context.Games.SingleOrDefault(m => m.Id == id);

            if (Game == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Game, GameDTO>(Game));
        }


        // POST /api/Games
        [Authorize(Roles = RoleName.CanManageMovies)]
        [HttpPost]
        public IHttpActionResult CreateGame(GameDTO GameDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var Game = Mapper.Map<GameDTO, Game>(GameDto);
            _context.Games.Add(Game);
            _context.SaveChanges();

            GameDto.Id = Game.Id;

            return Created(new Uri(Request.RequestUri + "/" + Game.Id), GameDto);

        }

        // PUT /api/Games/1
        [Authorize(Roles = RoleName.CanManageMovies)]
        [HttpPut]
        public void UpdateGame(int id, GameDTO GameDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var GameInDb = _context.Games.SingleOrDefault(m => m.Id == id);

            if (GameInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(GameDto, GameInDb);

            _context.SaveChanges();
        }


        // DELETE /api/Games/1
        [Authorize(Roles = RoleName.CanManageMovies)]
        [HttpDelete]
        public void DeleteGame(int id)
        {
            var GameInDb = _context.Games.SingleOrDefault(m => m.Id == id);

            if (GameInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Games.Remove(GameInDb);
            _context.SaveChanges();
        }



    }
}
