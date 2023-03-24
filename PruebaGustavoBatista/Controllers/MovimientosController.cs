using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PruebaGustavoBatista.DTOS;
using PruebaGustavoBatista.Models;
using PruebaGustavoBatista.Services;

namespace PruebaGustavoBatista.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MovimientosController : ControllerBase
    {
        private readonly IMovimientosService _movimientosService;
        private readonly ILogger<MovimientosController> _logger;
        private readonly ICurrentUserService _currentUserService;
        private readonly UserManager<ApplicationUser> _userManager;
        public MovimientosController(IMovimientosService movimientosService, ILogger<MovimientosController> logger, ICurrentUserService currentUserService, UserManager<ApplicationUser> userManager)
        {
            _movimientosService = movimientosService;
            _logger = logger;
            _currentUserService = currentUserService;
            _userManager = userManager;
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SummaryDto))]
        [HttpGet("Movimientos")]
        public async Task<IActionResult> GetSummaryById()
        {
            _logger.LogInformation($"Iniciando proceso de obtencion de datos. {DateTime.Now}");

            try
            {
                if(_currentUserService.User== default)
                    return NotFound();
                
                var user = await _userManager.GetUserAsync(_currentUserService.User);
                
                var result = new object();
                
                if(user?.Nit!=null)
                    result = await _movimientosService.GetSummaryAsync(user.Nit);

                return Ok(result);
            }
            catch (Exception)
            {
                return Problem();
            }
        }
    }
}
