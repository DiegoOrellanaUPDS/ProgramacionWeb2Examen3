using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExamenFinalProgramacionWeb2.Core.Entidades;

namespace ExamenFinalProgramacionWeb2.Data
{
    public class ExamenFinalProgramacionWeb2Context : DbContext
    {
        public ExamenFinalProgramacionWeb2Context (DbContextOptions<ExamenFinalProgramacionWeb2Context> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Cliente { get; set; } = default!;
        public DbSet<Credito> Credito { get; set; } = default!;
        public DbSet<Factura> Factura { get; set; } = default!;
        public DbSet<OrdenCompra> OrdenCompra { get; set; } = default!;
        public DbSet<Pago> Pago { get; set; } = default!;
        public DbSet<Proveedor> Proveedor { get; set; } = default!;
    }
}
