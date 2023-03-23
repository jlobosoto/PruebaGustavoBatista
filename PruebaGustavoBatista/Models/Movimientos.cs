using PruebaGustavoBatista.Models.Enums;

namespace PruebaGustavoBatista.Models
{
    public class Movimientos
    {
        public int Id { get; set; }
        public TipoMovimiento Id_Tipo_Movimiento { get; set; }
        public DateTime Fecha { get; set; }
        public Decimal Valor { get; set; }
        public required string UserId { get; set; }
        public required virtual ApplicationUser User { get; set; }
    }
}
