using System.Security.Claims;

namespace PruebaGustavoBatista.Services;

public interface ICurrentUserService
{
    ClaimsPrincipal? User { get; }
}
