﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BmdbWebApi.Data;
using BmdbWebApi.Models;

namespace BmdbWebApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase {
        private readonly AppDbContext _context;

        public ActorsController(AppDbContext context) {
            _context = context;
        }

        // GET: api/lastName
        [HttpGet("search/{searchLastName}")]
        public async Task<ActionResult<IEnumerable<Actor>>> SearchByLastName(string searchLastName) {
            return await _context.Actors.Where(a => a.LastName.Contains(searchLastName)).ToListAsync();
        }

        // GET: api/Actors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actor>>> GetActor() {
            return await _context.Actors.ToListAsync();
        }

        // GET: api/Actors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Actor>> GetActor(int id) {
            var actor = await _context.Actors.FindAsync(id);

            if (actor == null) {
                return NotFound();
            }

            return actor;
        }

        // PUT: api/Actors
        [HttpPut]
        public async Task<IActionResult> PutActor(Actor actor) {
            return await PutActor(actor.Id, actor);
        }



        // PUT: api/Actors/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActor(int id, Actor actor) {
            if (id != actor.Id) {
                return BadRequest();
            }

            _context.Entry(actor).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!ActorExists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Actors
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Actor>> PostActor(Actor actor) {
            _context.Actors.Add(actor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActor", new { id = actor.Id }, actor);
        }

        // DELETE: api/Actors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Actor>> DeleteActor(int id) {
            var actor = await _context.Actors.FindAsync(id);
            if (actor == null) {
                return NotFound();
            }

            _context.Actors.Remove(actor);
            await _context.SaveChangesAsync();

            return actor;
        }

        private bool ActorExists(int id) {
            return _context.Actors.Any(e => e.Id == id);
        }
    }
}
