using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExamenFinalProgramacionWeb2.Data;
using ExamenFinalProgramacionWeb2.Entidades;

namespace ExamenFinalProgramacionWeb2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenComprasController : ControllerBase
    {
        private readonly ExamenFinalProgramacionWeb2Context _context;

        public OrdenComprasController(ExamenFinalProgramacionWeb2Context context)
        {
            _context = context;
        }

        // GET: api/OrdenCompras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdenCompra>>> GetOrdenCompra()
        {
            return await _context.OrdenCompra.ToListAsync();
        }

        // GET: api/OrdenCompras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrdenCompra>> GetOrdenCompra(int id)
        {
            var ordenCompra = await _context.OrdenCompra.FindAsync(id);

            if (ordenCompra == null)
            {
                return NotFound();
            }

            return ordenCompra;
        }

        // PUT: api/OrdenCompras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdenCompra(int id, OrdenCompra ordenCompra)
        {
            if (id != ordenCompra.Id)
            {
                return BadRequest();
            }

            _context.Entry(ordenCompra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdenCompraExists(id))
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

        // POST: api/OrdenCompras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrdenCompra>> PostOrdenCompra(OrdenCompra ordenCompra)
        {
            _context.OrdenCompra.Add(ordenCompra);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrdenCompra", new { id = ordenCompra.Id }, ordenCompra);
        }

        // DELETE: api/OrdenCompras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrdenCompra(int id)
        {
            var ordenCompra = await _context.OrdenCompra.FindAsync(id);
            if (ordenCompra == null)
            {
                return NotFound();
            }

            _context.OrdenCompra.Remove(ordenCompra);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrdenCompraExists(int id)
        {
            return _context.OrdenCompra.Any(e => e.Id == id);
        }
    }
}
