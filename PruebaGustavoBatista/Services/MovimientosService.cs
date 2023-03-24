using Microsoft.EntityFrameworkCore;
using PruebaGustavoBatista.Data;
using PruebaGustavoBatista.DTOS;

namespace PruebaGustavoBatista.Services
{

    public interface IMovimientosService
    {
        Task<SummaryDto> GetSummaryAsync(string nit);
    }

    public class MovimientosService:IMovimientosService
    {
        private readonly ApplicationDbContext _dbContext;

        public MovimientosService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<SummaryDto> GetSummaryAsync(string nit)
        {
            var user = _dbContext.Users.Where(x => x.Nit == nit).FirstOrDefault();
            
            if(user == null) { return null; }

            var movimientos = await _dbContext.Movimientos
               .Include(m => m.User)
               .Where(m => m.UserId == nit)
               .ToListAsync();

            return new SummaryDto { DatosCliente=new Cliente { Nit=nit, Nombre=user.UserName??"Por Derterminar", CupoAprobado=user.Cupo }, SaldoEnCartera=GetSaldo(nit), FechaRegistro= user.FechadeRegistro };
        }

        private decimal GetSaldo(string nit)
        {
            var ingresos=_dbContext.Movimientos.Where(x => x.User.Nit == nit && x.Id_Tipo_Movimiento==Models.Enums.TipoMovimiento.ingreso).Sum(y => y.Valor);
            var egresos = _dbContext.Movimientos.Where(x => x.User.Nit == nit && x.Id_Tipo_Movimiento == Models.Enums.TipoMovimiento.egreso).Sum(y => y.Valor);
            var cupo = _dbContext.Users.Single(x => x.Nit == nit).Cupo;
            return cupo - (ingresos - egresos);
        }
    }


}
