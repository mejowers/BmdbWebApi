using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BmdbWebApi.Data;
using BmdbWebApi.Models;

namespace BmdbWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieGenresController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MovieGenresController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/MovieGenres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieGenre>>> GetMovieGenres()
        {
            return await _context.MovieGenres.ToListAsync();
        }

        // GET: api/MovieGenres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieGenre>> GetMovieGenre(int id)
        {
            var movieGenre = await _context.MovieGenres.FindAsync(id);

            if (movieGenre == null)
            {
                return NotFound();
            }

            return movieGenre;
        }

        // PUT: api/MovieGenres/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovieGenre(int id, MovieGenre movieGenre)
        {
            if (id != movieGenre.Id)
            {
                return BadRequest();
            }

            _context.Entry(movieGenre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieGenreExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MovieGenres
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MovieGenre>> PostMovieGenre(MovieGenre movieGenre)
        {
            _context.MovieGenres.Add(movieGenre);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovieGenre", new { id = movieGenre.Id }, movieGenre);
        }

        // DELETE: api/MovieGenres/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MovieGenre>> DeleteMovieGenre(int id)
        {
            var movieGenre = await _context.MovieGenres.FindAsync(id);
            if (movieGenre == null)
            {
                return NotFound();
            }

            _context.MovieGenres.Remove(movieGenre);
            await _context.SaveChangesAsync();

            return movieGenre;
        }

        private bool MovieGenreExists(int id)
        {
            return _context.MovieGenres.Any(e => e.Id == id);
        }
    }
}
