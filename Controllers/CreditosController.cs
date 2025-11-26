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
    public class CreditosController : ControllerBase
    {
        private readonly ExamenFinalProgramacionWeb2Context _context;

        public CreditosController(ExamenFinalProgramacionWeb2Context context)
        {
            _context = context;
        }

        // GET: api/Creditoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Credito>>> GetCredito()
        {
            return await _context.Credito.ToListAsync();
        }

        // GET: api/Creditoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Credito>> GetCredito(int id)
        {
            var credito = await _context.Credito.FindAsync(id);

            if (credito == null)
            {
                return NotFound();
            }

            return credito;
        }

        // PUT: api/Creditoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCredito(int id, Credito credito)
        {
            if (id != credito.Id)
            {
                return BadRequest();
            }

            _context.Entry(credito).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CreditoExists(id))
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

        // POST: api/Creditoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Credito>> PostCredito(Credito credito)
        {
            _context.Credito.Add(credito);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCredito", new { id = credito.Id }, credito);
        }

        // DELETE: api/Creditoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCredito(int id)
        {
            var credito = await _context.Credito.FindAsync(id);
            if (credito == null)
            {
                return NotFound();
            }

            _context.Credito.Remove(credito);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CreditoExists(int id)
        {
            return _context.Credito.Any(e => e.Id == id);
        }
    }
}
