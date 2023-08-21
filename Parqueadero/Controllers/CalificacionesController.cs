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
    public class CalificacionesController : ControllerBase
    {
        private readonly PqDBContext _context;

        public CalificacionesController(PqDBContext context)
        {
            _context = context;
        }

        // GET: api/Calificaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Calificaciones>>> GetCalificaciones()
        {
          if (_context.Calificaciones == null)
          {
              return NotFound();
          }
            return await _context.Calificaciones.Include(x=> x.Visita).ToListAsync();
        }

        // GET: api/Calificaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Calificaciones>> GetCalificaciones(long id)
        {
          if (_context.Calificaciones == null)
          {
              return NotFound();
          }
            var calificaciones = await _context.Calificaciones.FindAsync(id);

            if (calificaciones == null)
            {
                return NotFound();
            }

            return calificaciones;
        }

        // PUT: api/Calificaciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalificaciones(long id, Calificaciones calificaciones)
        {
            if (id != calificaciones.Id)
            {
                return BadRequest();
            }

            _context.Entry(calificaciones).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalificacionesExists(id))
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

        // POST: api/Calificaciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Calificaciones>> PostCalificaciones(Calificaciones calificaciones)
        {
          if (_context.Calificaciones == null)
          {
              return Problem("Entity set 'PqDBContext.Calificaciones'  is null.");
          }
            _context.Calificaciones.Add(calificaciones);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCalificaciones", new { id = calificaciones.Id }, calificaciones);
        }

        // DELETE: api/Calificaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalificaciones(long id)
        {
            if (_context.Calificaciones == null)
            {
                return NotFound();
            }
            var calificaciones = await _context.Calificaciones.FindAsync(id);
            if (calificaciones == null)
            {
                return NotFound();
            }

            _context.Calificaciones.Remove(calificaciones);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CalificacionesExists(long id)
        {
            return (_context.Calificaciones?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
