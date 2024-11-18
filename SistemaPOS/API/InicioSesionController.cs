using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaPOS.Aplication.DTOs;
using SistemaPOS.Aplication.Services;

namespace SistemaPOS.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class InicioSesionController : ControllerBase
    {
        private readonly InicioSesionService _inicioSesionService;

        public InicioSesionController(InicioSesionService inicioSesionService)
        {
            _inicioSesionService = inicioSesionService;
        }

        [HttpPost]
        public async Task<UsuarioSesionDto> Ingresar(UsuarioCredencialesDto credencialesDto)
        {
            return await _inicioSesionService.Ingresar(credencialesDto.Usuario, credencialesDto.Password);
        }
    }
}
