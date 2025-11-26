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
    public class FacturasController : ControllerBase
    {
        private readonly ExamenFinalProgramacionWeb2Context context;

        public FacturasController(ExamenFinalProgramacionWeb2Context context)
        {
            this.context = context;
        }

        [HttpGet("Listar")]
        public async Task<IActionResult> Listar()
        {
            return Ok(await (from f in context.Factura
                             where f.Estado != "Borrado"
                             select f.ToDto()).ToListAsync());
        }

        [HttpGet("ListarBorrados")]
        public async Task<IActionResult> ListarBorrados()
        {
            return Ok(await (from f in context.Factura
                             where f.Estado == "Borrado"
                             select f.ToDto()).ToListAsync());
        }

        [HttpGet("{codigo}")]
        public async Task<IActionResult> Get(int codigo)
        {
            var factura = await (from f in context.Factura
                                 where f.Codigo == codigo && f.Estado != "Borrado"
                                 select f.ToDto()).FirstOrDefaultAsync();

            if (factura == null) return NotFound();
            return Ok(factura);
        }

        [HttpPost("crear")]
        public async Task<IActionResult> Crear(FacturaDto dto)
        {
            var existe = await context.Factura.FirstOrDefaultAsync(x => x.Codigo == dto.Codigo);
            if (existe != null) return BadRequest("La factura ya existe.");

            var entidad = new Factura
            {
                Codigo = dto.Codigo,
                ClienteCi = dto.ClienteCi,
                Fecha = dto.Fecha,
                MontoTotal = dto.MontoTotal,
                Pagada = dto.Pagada,
                Estado = "Activo"
            };

            context.Factura.Add(entidad);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetCredito", new { codigo = entidad.Codigo}, entidad.ToDto());
        }

        [HttpPut("{codigo}")]
        public async Task<IActionResult> Actualizar(int codigo, FacturaDto dto)
        {
            var factura = await context.Factura.FirstOrDefaultAsync(x => x.Codigo == codigo && x.Estado != "Borrado");
            if (factura == null) return NotFound();

            factura.MontoTotal = dto.MontoTotal;
            factura.Pagada = dto.Pagada;

            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{codigo}")]
        public async Task<IActionResult> Borrar(int codigo)
        {
            var factura = await context.Factura.FirstOrDefaultAsync(x => x.Codigo == codigo);
            if (factura == null) return NotFound();

            factura.Estado = "Borrado";
            await context.SaveChangesAsync();
            return NoContent();
        }
    }

}
