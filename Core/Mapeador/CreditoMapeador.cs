using ExamenFinalProgramacionWeb2.Core.DTOs;
using ExamenFinalProgramacionWeb2.Core.Entidades;

namespace ExamenFinalProgramacionWeb2.Core.Mapeador
{
    public static class CreditoMapeador
    {
        public static CreditoDto ToDto(this Credito credito)
        {
            return new CreditoDto
            {
                Codigo = credito.Codigo,
                ClienteCi = credito.ClienteCi,
                LimiteCredito = credito.LimiteCredito,
                SaldoUsado = credito.SaldoUsado
            };
        }
        public static Credito ToEntidad(this CreditoDto creditodto)
        {
            return new Credito
            {
                Codigo = creditodto.Codigo,
                ClienteCi = creditodto.ClienteCi,
                LimiteCredito = creditodto.LimiteCredito,
                SaldoUsado = creditodto.SaldoUsado,
                Estado = "Activo"
            };
        }
    }
}
