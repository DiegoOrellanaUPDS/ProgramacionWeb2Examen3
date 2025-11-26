using ExamenFinalProgramacionWeb2.Core.DTOs;
using ExamenFinalProgramacionWeb2.Core.Entidades;
using ExamenFinalProgramacionWeb2.Core.Mapeador;
using ExamenFinalProgramacionWeb2.Data;
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
    public class PagosController : ControllerBase
    {
        private readonly ExamenFinalProgramacionWeb2Context context;

        public PagosController(ExamenFinalProgramacionWeb2Context context)
        {
            this.context = context;
        }

        [HttpGet("Listar")]
        public async Task<IActionResult> Listar()
        {
            return Ok(await (from p in context.Pago
                             where p.Estado != "Borrado"
                             select p.ToDto()).ToListAsync());
        }

        [HttpGet("ListarBorrados")]
        public async Task<IActionResult> ListarBorrados()
        {
            return Ok(await (from p in context.Pago
                             where p.Estado == "Borrado"
                             select p.ToDto()).ToListAsync());
        }

        [HttpGet("{codigo}")]
        public async Task<IActionResult> Get(int codigo)
        {
            var pago = await (from p in context.Pago
                              where p.Codigo == codigo && p.Estado != "Borrado"
                              select p.ToDto()).FirstOrDefaultAsync();

            if (pago == null) return NotFound();
            return Ok(pago);
        }

        [HttpPost("crear")]
        public async Task<IActionResult> Crear(PagoDto dto)
        {
            var existe = await context.Pago.FirstOrDefaultAsync(x => x.Codigo == dto.Codigo);
            if (existe != null) return BadRequest("El pago ya existe.");

            var entidad = new Pago
            {
                Codigo = dto.Codigo,
                FacturaCodigo = dto.FacturaCodigo,
                FechaPago = dto.FechaPago,
                MontoPagado = dto.MontoPagado,
                Estado = "Activo"
            };

            context.Pago.Add(entidad);
            await context.SaveChangesAsync();

            return CreatedAtAction("Get", new { mensaje = "pago creado exitosamente" });
        }

        [HttpPut("{codigo}")]
        public async Task<IActionResult> Actualizar(int codigo, PagoDto dto)
        {
            var pago = await context.Pago.FirstOrDefaultAsync(x => x.Codigo == codigo && x.Estado != "Borrado");
            if (pago == null) return NotFound();

            pago.MontoPagado = dto.MontoPagado;

            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{codigo}")]
        public async Task<IActionResult> Borrar(int codigo)
        {
            var pago = await context.Pago.FirstOrDefaultAsync(x => x.Codigo == codigo);
            if (pago == null) return NotFound();

            pago.Estado = "Borrado";
            await context.SaveChangesAsync();
            return NoContent();
        }
    }

}
