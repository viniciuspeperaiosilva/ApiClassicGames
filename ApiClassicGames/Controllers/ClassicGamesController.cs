using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiClassicGames.Data;
using ApiClassicGames.Models;

namespace ApiClassicGames.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassicGamesController : ControllerBase
    {
        private readonly DbGamesContext _context;

        public ClassicGamesController(DbGamesContext context)
        {
            _context = context;
        }

        // GET: api/ClassicGames
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassicGame>>> GetClassicGame()
        {
          if (_context.ClassicGame == null)
          {
              return NotFound();
          }
            return await _context.ClassicGame.ToListAsync();
        }

        // GET: api/ClassicGames/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClassicGame>> GetClassicGame(int id)
        {
          if (_context.ClassicGame == null)
          {
              return NotFound();
          }
            var classicGame = await _context.ClassicGame.FindAsync(id);

            if (classicGame == null)
            {
                return NotFound();
            }

            return classicGame;
        }

        // PUT: api/ClassicGames/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClassicGame(int id, ClassicGame classicGame)
        {
            if (id != classicGame.Id)
            {
                return BadRequest();
            }

            _context.Entry(classicGame).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassicGameExists(id))
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

        // POST: api/ClassicGames
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClassicGame>> PostClassicGame(ClassicGame classicGame)
        {
          if (_context.ClassicGame == null)
          {
              return Problem("Entity set 'DbGamesContext.ClassicGame'  is null.");
          }
            _context.ClassicGame.Add(classicGame);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClassicGame", new { id = classicGame.Id }, classicGame);
        }

        // DELETE: api/ClassicGames/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClassicGame(int id)
        {
            if (_context.ClassicGame == null)
            {
                return NotFound();
            }
            var classicGame = await _context.ClassicGame.FindAsync(id);
            if (classicGame == null)
            {
                return NotFound();
            }

            _context.ClassicGame.Remove(classicGame);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClassicGameExists(int id)
        {
            return (_context.ClassicGame?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
