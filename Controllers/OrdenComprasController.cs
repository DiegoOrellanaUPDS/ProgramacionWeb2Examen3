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
    public class OrdenComprasController : ControllerBase
    {
        private readonly ExamenFinalProgramacionWeb2Context context;

        public OrdenComprasController(ExamenFinalProgramacionWeb2Context context)
        {
            this.context = context;
        }

        [HttpGet("Listar")]
        public async Task<IActionResult> Listar()
        {
            return Ok(await (from o in context.OrdenCompra
                             where o.Estado != "Borrado"
                             select o.ToDto()).ToListAsync());
        }

        [HttpGet("ListarBorrados")]
        public async Task<IActionResult> ListarBorrados()
        {
            return Ok(await (from o in context.OrdenCompra
                             where o.Estado == "Borrado"
                             select o.ToDto()).ToListAsync());
        }

        [HttpGet("{codigo}")]
        public async Task<IActionResult> Get(int codigo)
        {
            var orden = await (from o in context.OrdenCompra
                               where o.Codigo == codigo && o.Estado != "Borrado"
                               select o.ToDto()).FirstOrDefaultAsync();

            if (orden == null) return NotFound();
            return Ok(orden);
        }

        [HttpPost("crear")]
        public async Task<IActionResult> Crear(OrdenCompraDto dto)
        {
            var existe = await context.OrdenCompra.FirstOrDefaultAsync(x => x.Codigo == dto.Codigo);
            if (existe != null) return BadRequest("La orden ya existe.");

            var entidad = new OrdenCompra
            {
                Codigo = dto.Codigo,
                ProveedorCodigo = dto.ProveedorCodigo,
                Fecha = dto.Fecha,
                Producto = dto.Producto,
                Cantidad = dto.Cantidad,
                CostoTotal = dto.CostoTotal,
                Estado = "Activo"
            };

            context.OrdenCompra.Add(entidad);
            await context.SaveChangesAsync();

            return CreatedAtAction("Get", new { mensaje = "orden creada exitosamente" });
        }

        [HttpPut("{codigo}")]
        public async Task<IActionResult> Actualizar(int codigo, OrdenCompraDto dto)
        {
            var orden = await context.OrdenCompra.FirstOrDefaultAsync(x => x.Codigo == codigo && x.Estado != "Borrado");
            if (orden == null) return NotFound();

            orden.Producto = dto.Producto;
            orden.Cantidad = dto.Cantidad;
            orden.CostoTotal = dto.CostoTotal;

            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{codigo}")]
        public async Task<IActionResult> Borrar(int codigo)
        {
            var orden = await context.OrdenCompra.FirstOrDefaultAsync(x => x.Codigo == codigo);
            if (orden == null) return NotFound();

            orden.Estado = "Borrado";
            await context.SaveChangesAsync();
            return NoContent();
        }
    }

}
