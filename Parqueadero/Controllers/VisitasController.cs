using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parqueadero.Data;
using Parqueadero.Data.Models;

namespace Parqueadero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitasController : ControllerBase
    {
        private readonly PqDBContext _context;

        public VisitasController(PqDBContext context)
        {
            _context = context;
        }

        // GET: api/Visitas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Visita>>> GetVisita()
        {
          if (_context.Visita == null)
          {
              return NotFound();
          }
            return await _context.Visita.Include(x=> x.Client).ToListAsync();
        }

        // GET: api/Visitas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Visita>> GetVisita(long id)
        {
          if (_context.Visita == null)
          {
              return NotFound();
          }
            var visita = await _context.Visita.FindAsync(id);

            if (visita == null)
            {
                return NotFound();
            }

            return visita;
        }

        // PUT: api/Visitas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVisita(long id, Visita visita)
        {
            if (id != visita.Id)
            {
                return BadRequest();
            }

            _context.Entry(visita).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VisitaExists(id))
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

        // POST: api/Visitas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Visita>> PostVisita(Visita visita)
        {
          if (_context.Visita == null)
          {
              return Problem("Entity set 'PqDBContext.Visita'  is null.");
          }
            _context.Visita.Add(visita);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVisita", new { id = visita.Id }, visita);
        }

        // DELETE: api/Visitas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVisita(long id)
        {
            if (_context.Visita == null)
            {
                return NotFound();
            }
            var visita = await _context.Visita.FindAsync(id);
            if (visita == null)
            {
                return NotFound();
            }

            _context.Visita.Remove(visita);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VisitaExists(long id)
        {
            return (_context.Visita?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
