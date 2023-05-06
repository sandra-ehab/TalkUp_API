using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TalkUp.Models;

namespace TalkUp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        private readonly TalkUpContext _context;

        public MediaController(TalkUpContext context)
        {
            _context = context;
        }

        // GET: api/Media
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medium>>> GetMedia()
        {
          if (_context.Media == null)
          {
              return NotFound();
          }
            return await _context.Media.ToListAsync();
        }

        // GET: api/Media/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Medium>> GetMedium(int id)
        {
          if (_context.Media == null)
          {
              return NotFound();
          }
            var medium = await _context.Media.FindAsync(id);

            if (medium == null)
            {
                return NotFound();
            }

            return medium;
        }

        // PUT: api/Media/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedium(int id, Medium medium)
        {
            if (id != medium.MediaId)
            {
                return BadRequest();
            }

            _context.Entry(medium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MediumExists(id))
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

        // POST: api/Media
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Medium>> PostMedium(Medium medium)
        {
          if (_context.Media == null)
          {
              return Problem("Entity set 'TalkUpContext.Media'  is null.");
          }
            _context.Media.Add(medium);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedium", new { id = medium.MediaId }, medium);
        }

        // DELETE: api/Media/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedium(int id)
        {
            if (_context.Media == null)
            {
                return NotFound();
            }
            var medium = await _context.Media.FindAsync(id);
            if (medium == null)
            {
                return NotFound();
            }

            _context.Media.Remove(medium);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MediumExists(int id)
        {
            return (_context.Media?.Any(e => e.MediaId == id)).GetValueOrDefault();
        }
    }
}
