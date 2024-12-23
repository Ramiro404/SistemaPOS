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
        public async Task<IActionResult> Crear(CrearMedioPagoDto crearMedioPagoDto)
        {
            try
            {
                await _medioPagoService.CrearMedioPagoAsync(crearMedioPagoDto);
                return CreatedAtAction(
                    nameof(Crear),
                    new Utils.SuccessResult<dynamic>(null));
            }catch(Exception ex)
            {
                return BadRequest(new Utils.BadResult(ex.Message));
            }
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Editar(int id, EditarMedioPago editarMedioPagoDto)
        {
            try
            {
                await _medioPagoService.EditarMedioPagoAsync(id, editarMedioPagoDto);
                return Ok(new Utils.SuccessResult<dynamic>(null));
            }
            catch(Exception ex)
            {
                return BadRequest(new Utils.BadResult(ex.Message));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            try
            {
                var data = await _medioPagoService.ListarMedioPagoAsync();
                return Ok(new Utils.SuccessResult<List<MedioPagoDto>>(data));
            }
            catch (Exception ex)
            {
                return BadRequest(new Utils.BadResult(ex.Message));
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Eliminar(int id )
        {
            try
            {
                await _medioPagoService.EliminarMedioPagoAsync(id);
                return Ok(new Utils.SuccessResult<dynamic>(null));
            }
            catch (Exception ex)
            {
                return BadRequest(new Utils.BadResult(ex.Message));
            }
        }
    }
}
