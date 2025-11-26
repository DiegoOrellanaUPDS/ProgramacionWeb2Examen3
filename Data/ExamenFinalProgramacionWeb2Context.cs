using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExamenFinalProgramacionWeb2.Entidades;

namespace ExamenFinalProgramacionWeb2.Data
{
    public class ExamenFinalProgramacionWeb2Context : DbContext
    {
        public ExamenFinalProgramacionWeb2Context (DbContextOptions<ExamenFinalProgramacionWeb2Context> options)
            : base(options)
        {
        }

        public DbSet<ExamenFinalProgramacionWeb2.Entidades.Cliente> Cliente { get; set; } = default!;
        public DbSet<ExamenFinalProgramacionWeb2.Entidades.Credito> Credito { get; set; } = default!;
        public DbSet<ExamenFinalProgramacionWeb2.Entidades.Factura> Factura { get; set; } = default!;
        public DbSet<ExamenFinalProgramacionWeb2.Entidades.OrdenCompra> OrdenCompra { get; set; } = default!;
        public DbSet<ExamenFinalProgramacionWeb2.Entidades.Pago> Pago { get; set; } = default!;
        public DbSet<ExamenFinalProgramacionWeb2.Entidades.Proveedor> Proveedor { get; set; } = default!;
    }
}
