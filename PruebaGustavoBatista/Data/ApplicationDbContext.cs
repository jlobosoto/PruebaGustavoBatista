using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using PruebaGustavoBatista.Models;
using System.Reflection;

namespace PruebaGustavoBatista.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {
        }
        public DbSet<PruebaGustavoBatista.Models.Movimientos> Movimientos { get; set; } = default!;
    }
}