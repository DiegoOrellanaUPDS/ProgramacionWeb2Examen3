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
    public class ProveedoresController : ControllerBase
    {
        private readonly ExamenFinalProgramacionWeb2Context context;

        public ProveedoresController(ExamenFinalProgramacionWeb2Context context)
        {
            this.context = context;
        }

        [HttpGet("Listar")]
        public async Task<IActionResult> Listar()
        {
            return Ok(await (from p in context.Proveedor
                             where p.Estado != "Borrado"
                             select p.ToDto()).ToListAsync());
        }

        [HttpGet("ListarBorrados")]
        public async Task<IActionResult> ListarBorrados()
        {
            return Ok(await (from p in context.Proveedor
                             where p.Estado == "Borrado"
                             select p.ToDto()).ToListAsync());
        }

        [HttpGet("{codigo}")]
        public async Task<IActionResult> Get(int codigo)
        {
            var prov = await (from p in context.Proveedor
                              where p.Codigo == codigo && p.Estado != "Borrado"
                              select p.ToDto()).FirstOrDefaultAsync();

            if (prov == null) return NotFound();
            return Ok(prov);
        }

        [HttpPost("crear")]
        public async Task<IActionResult> Crear(ProveedorDto dto)
        {
            var existe = await context.Proveedor.FirstOrDefaultAsync(x => x.Codigo == dto.Codigo);
            if (existe != null) return BadRequest("El proveedor ya existe.");

            var entidad = new Proveedor
            {
                Codigo = dto.Codigo,
                Nombre = dto.Nombre,
                Categoria = dto.Categoria,
                Calificacion = dto.Calificacion,
                Estado = "Activo"
            };

            context.Proveedor.Add(entidad);
            await context.SaveChangesAsync();

            return CreatedAtAction("Get", new { mensaje = "proveedor creado exitosamente" });
        }

        [HttpPut("{codigo}")]
        public async Task<IActionResult> Actualizar(int codigo, ProveedorDto dto)
        {
            var prov = await context.Proveedor.FirstOrDefaultAsync(x => x.Codigo == codigo && x.Estado != "Borrado");
            if (prov == null) return NotFound();

            prov.Nombre = dto.Nombre;
            prov.Categoria = dto.Categoria;
            prov.Calificacion = dto.Calificacion;

            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{codigo}")]
        public async Task<IActionResult> Borrar(int codigo)
        {
            var prov = await context.Proveedor.FirstOrDefaultAsync(x => x.Codigo == codigo);
            if (prov == null) return NotFound();

            prov.Estado = "Borrado";
            await context.SaveChangesAsync();
            return NoContent();
        }
    }



}
