using ExamenFinalProgramacionWeb2.Core.DTOs;
using ExamenFinalProgramacionWeb2.Core.Entidades;
using ExamenFinalProgramacionWeb2.Core.Mapeador;
using ExamenFinalProgramacionWeb2.Data;
using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        [HttpGet("{ci}")]
        public async Task<IActionResult> GetCliente(string ci)
        {
            var cliente = await (from c in context.Cliente
                                 where c.Estado != "Borrado" && c.Ci == ci
                                 select c.ToDto()).FirstOrDefaultAsync();

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{ci}")]
        public async Task<IActionResult> PutCliente(string ci, ClienteDto dto)
        {
            var cliente = await (from c in context.Cliente
                                 where c.Ci == ci && c.Estado != "Borrado"
                                 select c).FirstOrDefaultAsync();
            if (cliente == null)
                return NotFound("No existe el cliente.");

            // Actualizás SOLO lo editable
            cliente.Nombre = dto.Nombre;
            cliente.Categoria = dto.Categoria;

            await context.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/Clientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("crear")]
        public async Task<IActionResult> PostCliente(ClienteDto dto)
        {
            var clienteaux = await (from c in context.Cliente
                                 where c.Ci == dto.Ci
                                 select c).FirstOrDefaultAsync();
            if (clienteaux != null)
            {
                return BadRequest("El cliente con la CI proporcionada ya existe.");
            }
            var cliente = new Cliente
            {
                Ci = dto.Ci,
                Nombre = dto.Nombre,
                Categoria = dto.Categoria,
                Estado = "Activo"
            };
            context.Cliente.Add(cliente);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetCredito", new { ci = cliente.Ci }, cliente.ToDto());
        }

        [HttpDelete("{ci}")]
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
