using Microsoft.AspNetCore.Mvc;
using SistemaPOS.Aplication.DTOs;
using SistemaPOS.Aplication.Services;

namespace SistemaPOS.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedioPagoController : ControllerBase
    {
        private readonly MedioPagoService _medioPagoService;

        public MedioPagoController(MedioPagoService mediioPagoService)
        {
            _medioPagoService = mediioPagoService;
        }

        [HttpPost]
        public async Task<ActionResult> Crear(CrearMedioPagoDto crearMedioPagoDto)
        {
            await _medioPagoService.CrearMedioPagoAsync(crearMedioPagoDto);
            return Created();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Editar(int id, EditarMedioPago editarMedioPagoDto)
        {
            await _medioPagoService.EditarMedioPagoAsync(id, editarMedioPagoDto);
            return Ok();
        }

        [HttpGet]
        public async Task<List<MedioPagoDto>> Listar()
        {
            return await _medioPagoService.ListarMedioPagoAsync();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Eliminar(int id )
        {
            await _medioPagoService.EliminarMedioPagoAsync(id);
            return Ok();
        }
    }
}
