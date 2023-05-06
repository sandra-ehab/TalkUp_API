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
    public class ExpsController : ControllerBase
    {
        private readonly TalkUpContext _context;

        public ExpsController(TalkUpContext context)
        {
            _context = context;
        }

        // GET: api/Exps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exp>>> GetExps()
        {
          if (_context.Exps == null)
          {
              return NotFound();
          }
            return await _context.Exps.ToListAsync();
        }

        // GET: api/Exps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Exp>> GetExp(int id)
        {
          if (_context.Exps == null)
          {
              return NotFound();
          }
            var exp = await _context.Exps.FindAsync(id);

            if (exp == null)
            {
                return NotFound();
            }

            return exp;
        }

        // PUT: api/Exps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExp(int id, Exp exp)
        {
            if (id != exp.ExpId)
            {
                return BadRequest();
            }

            _context.Entry(exp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpExists(id))
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

        // POST: api/Exps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Exp>> PostExp(Exp exp)
        {
          if (_context.Exps == null)
          {
              return Problem("Entity set 'TalkUpContext.Exps'  is null.");
          }
            _context.Exps.Add(exp);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExp", new { id = exp.ExpId }, exp);
        }

        // DELETE: api/Exps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExp(int id)
        {
            if (_context.Exps == null)
            {
                return NotFound();
            }
            var exp = await _context.Exps.FindAsync(id);
            if (exp == null)
            {
                return NotFound();
            }

            _context.Exps.Remove(exp);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExpExists(int id)
        {
            return (_context.Exps?.Any(e => e.ExpId == id)).GetValueOrDefault();
        }
    }
}
