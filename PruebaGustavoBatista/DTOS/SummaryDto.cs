using Microsoft.AspNetCore.Mvc;

namespace PruebaGustavoBatista.DTOS
{
    public class SummaryDto
    {
        public required Cliente DatosCliente { get;set; }
        public decimal SaldoEnCartera { get;set; }
        public DateTime FechaRegistro { get;set; }
    }

    public class Cliente
    {
        public required string Nit { get; set; }
        public required string Nombre { get; set; }
        public Decimal CupoAprobado { get; set; }

    }
}
