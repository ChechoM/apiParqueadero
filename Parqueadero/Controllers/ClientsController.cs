﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parqueadero.Data;
using Parqueadero.Data.Dto;
using Parqueadero.Data.Models;
using Parqueadero.Services.Interfaces;

namespace Parqueadero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly PqDBContext _context;
        private readonly IClientService _clientService;

        public ClientsController(PqDBContext context, IClientService clientService)
        {
            _context = context;
            _clientService = clientService;
        }

        // GET: api/Clients
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClient()
        {
          if (_context.Client == null)
          {
              return NotFound();
          }
            return await _context.Client.Include(x=> x.User).ToListAsync();
        }


        // GET: api/Clients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(long id)
        {
            if (_context.Client == null)
            {
                return NotFound();
            }
            var client = await _context.Client.FindAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        // PUT: api/Clients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(long id, Client client)
        {
            if (id != client.Id)
            {
                return BadRequest();
            }

            _context.Entry(client).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
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

        // POST: api/Clients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Client>> PostClient(ClienteDto client)
        {
          if (_context.Client == null)
          {
              return Problem("Entity set 'PqDBContext.Client'  is null.");
          }
            Client cliente = new Client()
            {
                Disponibilidad = client.Disponibilidad,
                Direccion = client.Direccion,
                Descripcion = client.Descripcion,
                Datafono = client.Datafono,
                HorarioAbre = client.HorarioAbre,
                HorarioCierre = client.HorarioCierre,
                Latitud = client.Latitud,
                Longitud = client.Longitud,
                Name = client.Name,
                Nit = client.Nit,
                Techo = client.Techo,
                UserId = client.UserId,
                ValorHora = client.ValorHora,
                User = _context.User.Where(x=> x.Id == client.UserId).FirstOrDefault()

            };

            _context.Client.Add(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClient", new { id = cliente.Id }, cliente);
        }

        // POST: api/Clients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("ValidaPermisos")]
        public async Task<ActionResult<UserRole>> ValidaPermisos(long id)
        {
            if (_context.Client == null)
            {
                return Problem("Entity set 'PqDBContext.Client'  is null.");
            }

            UserRole respuesta =  this._clientService.ValidaPermisos(id);

            if (respuesta == null)
            {
                return Problem("Entity set 'PqDBContext.Client'  is null.");
            }
            return respuesta;

        }


        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(long id)
        {
            if (_context.Client == null)
            {
                return NotFound();
            }
            var client = await _context.Client.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            _context.Client.Remove(client);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClientExists(long id)
        {
            return (_context.Client?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
