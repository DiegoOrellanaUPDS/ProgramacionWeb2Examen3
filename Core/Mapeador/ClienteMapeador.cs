using ExamenFinalProgramacionWeb2.Core.DTOs;
using ExamenFinalProgramacionWeb2.Core.Entidades;

namespace ExamenFinalProgramacionWeb2.Core.Mapeador
{
    public static class ClienteMapeador
    {
        public static ClienteDto ToDto(this Cliente cliente)
        {
            return new ClienteDto
            {
                Ci = cliente.Ci,
                Nombre = cliente.Nombre,
                Categoria = cliente.Categoria
            };
        }
    }
}
