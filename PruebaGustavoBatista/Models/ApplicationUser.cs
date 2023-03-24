using Microsoft.AspNetCore.Identity;

namespace PruebaGustavoBatista.Models
{
    public class ApplicationUser : IdentityUser
    {
        public required string Nit { get; set; }
        public decimal Cupo { get; set; }
        public DateTime FechadeRegistro { get; set; }
        public virtual ICollection<Movimientos>? Movimientos { get; set; }
    }
}