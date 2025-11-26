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
    public class CreditosController : ControllerBase
    {
        private readonly ExamenFinalProgramacionWeb2Context context;

        public CreditosController(ExamenFinalProgramacionWeb2Context context)
        {
            this.context = context;
        }

        [HttpGet("Listar")]
        public async Task<IActionResult> GetCreditos()
        {
            return Ok(await (from c in context.Credito
                             where c.Estado != "Borrado"
                             select c.ToDto()).ToListAsync());
        }

        [HttpGet("ListarBorrados")]
        public async Task<IActionResult> GetCreditosBorrados()
        {
            return Ok(await (from c in context.Credito
                             where c.Estado == "Borrado"
                             select c.ToDto()).ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCredito(int id)
        {
            var credito = await (from c in context.Credito
                                 where c.Id == id && c.Estado != "Borrado"
                                 select c.ToDto()).FirstOrDefaultAsync();

            if (credito == null) return NotFound();
            return Ok(credito);
        }

        [HttpPost("crear")]
        public async Task<IActionResult> PostCredito(CreditoDto dto)
        {
            var credito = new Credito
            {
                Codigo = dto.Codigo,
                ClienteCi = dto.ClienteCi,
                LimiteCredito = dto.LimiteCredito,
                SaldoUsado = dto.SaldoUsado,
                Estado = "Activo"
            };

            context.Credito.Add(credito);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetCredito", new { ci = credito.Codigo }, credito.ToDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCredito(int id, CreditoDto dto)
        {
            var credito = await context.Credito.FirstOrDefaultAsync(x => x.Id == id);
            if (credito == null) return NotFound();

            credito.Codigo = dto.Codigo;
            credito.ClienteCi = dto.ClienteCi;
            credito.LimiteCredito = dto.LimiteCredito;
            credito.SaldoUsado = dto.SaldoUsado;

            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCredito(int id)
        {
            var credito = await context.Credito.FirstOrDefaultAsync(x => x.Id == id);
            if (credito == null) return NotFound();

            credito.Estado = "Borrado";
            await context.SaveChangesAsync();

            return NoContent();
        }
    }

}
