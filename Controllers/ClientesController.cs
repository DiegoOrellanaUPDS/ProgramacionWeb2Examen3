using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExamenFinalProgramacionWeb2.Core.Entidades;
using ExamenFinalProgramacionWeb2.Data;
using ExamenFinalProgramacionWeb2.Core.DTOs;
using ExamenFinalProgramacionWeb2.Core.Mapeador;

namespace ExamenFinalProgramacionWeb2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ExamenFinalProgramacionWeb2Context context;

        public ClientesController(ExamenFinalProgramacionWeb2Context context)
        {
            this.context = context;
        }

        // GET: api/Clientes
        [HttpGet("Listar")]
        public async Task<IActionResult> GetClientes()
        {
            return Ok(await (from c in context.Cliente
                             where c.Estado != "Borrado"
                             select c.ToDto()).ToListAsync());
        }
        [HttpGet("ListarBorrados")]
        public async Task<IActionResult> GetClientesBorrados()
        {
            return Ok(await (from c in context.Cliente
                             where c.Estado == "Borrado"
                             select c.ToDto()).ToListAsync());
        }
        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCliente(int ci)
        {
            var cliente = await (from c in context.Cliente
                                 where c.Estado != "Borrado"
                                 select c.ToDto()).FirstOrDefaultAsync();

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, ClienteDto clientedto)
        {
            var cliente = await (from c in context.Cliente
                                 where c.Ci == clientedto.Ci
                                 select c).FirstOrDefaultAsync();
            if (cliente == null)
            {
                return BadRequest();
            }

            context.Entry(cliente).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Clientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("crear")]
        public async Task<IActionResult> PostCliente(ClienteDto clientedto)
        {
            var cliente = new Cliente
            {
                Ci = clientedto.Ci,
                Nombre = clientedto.Nombre,
                Categoria = clientedto.Categoria,
                Estado = "Activo"
            };
            context.Cliente.Add(cliente);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetCliente", new { mensaje = "cliente creado exitosamente" });
        }

        [HttpDelete("{Ci}")]
        public async Task<IActionResult> DeleteCliente(string ci)
        {
            var cliente = await (from c in context.Cliente
                                 where c.Ci == ci
                                 select c).FirstOrDefaultAsync();
            if (cliente == null)
            {
                return NotFound();
            }
            cliente.Estado = "Borrado";
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
