using ExamenFinalProgramacionWeb2.Core.DTOs;
using ExamenFinalProgramacionWeb2.Core.Entidades;

namespace ExamenFinalProgramacionWeb2.Core.Mapeador
{
    public static class ProveedorMapeador
    {
        public static ProveedorDto ToDto(this Proveedor proveedor)
        {
            return new ProveedorDto
            {
                Codigo = proveedor.Codigo,
                Nombre = proveedor.Nombre,
                Categoria = proveedor.Categoria,
                Calificacion = proveedor.Calificacion
            };
        }
        public static Proveedor ToEntidad(this ProveedorDto proveedordto)
        {
            return new Proveedor
            {
                Codigo = proveedordto.Codigo,
                Nombre = proveedordto.Nombre,
                Categoria = proveedordto.Categoria,
                Calificacion = proveedordto.Calificacion,
                Estado = "Activo"
            };
        }
    }
}
