using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PruebaGustavoBatista.Models;
using PruebaGustavoBatista.Models.Enums;

namespace PruebaGustavoBatista.Data
{

    public class SeedData
    {
        public static void Seed(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            // context.Database.EnsureCreated() does not use migrations to create the database and therefore the database that is created cannot be later updated using migrations 
            // use context.Database.Migrate() instead
            context.Database.Migrate();

            if (context.Users.Any())
            {
                return;
            }

            // insert dummy data
            var user = new ApplicationUser { Nit = "1", UserName = "Usuario1@tempmail.com", Cupo=10000000, FechadeRegistro= DateTime.Now, EmailConfirmed=true, LockoutEnabled=true };
            var result = Task.Run(() => userManager.CreateAsync(user, "P@ssword1")).Result;

            context.Movimientos.AddRange(new List<Movimientos>() 
            { 
                new Movimientos { User=user, UserId=user.Nit, Fecha= DateTime.Now, Id_Tipo_Movimiento=TipoMovimiento.ingreso,Valor=10000},
                new Movimientos { User=user, UserId=user.Nit, Fecha= DateTime.Now, Id_Tipo_Movimiento=TipoMovimiento.ingreso,Valor=100000},
                new Movimientos { User=user, UserId=user.Nit, Fecha= DateTime.Now, Id_Tipo_Movimiento=TipoMovimiento.ingreso,Valor=250000},
                new Movimientos { User=user, UserId=user.Nit, Fecha= DateTime.Now, Id_Tipo_Movimiento=TipoMovimiento.ingreso,Valor=1000000},
                new Movimientos { User=user, UserId=user.Nit, Fecha= DateTime.Now, Id_Tipo_Movimiento=TipoMovimiento.egreso,Valor=500000},
                new Movimientos { User=user, UserId=user.Nit, Fecha= DateTime.Now, Id_Tipo_Movimiento=TipoMovimiento.egreso,Valor=250000 }

            });
            context.SaveChanges();
        }
    }
}
