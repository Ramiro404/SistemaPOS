using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaPOS.Aplication.DTOs;
using SistemaPOS.Aplication.Services;

namespace SistemaPOS.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConvenioController : ControllerBase
    {
        private readonly ConvenioService _convenioService;

        public ConvenioController(ConvenioService convenioService)
        {
            _convenioService = convenioService;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            try
            {
                var data = await _convenioService.ListarConvenioAsync();
                return Ok(new Utils.SuccessResult<List<ConvenioDto>>(data));
            }
            catch (Exception e)
            {
                return BadRequest(new Utils.BadResult(e.Message));
            }
        }

        [HttpPost]
        public async Task<ActionResult> Crear(CrearConvenioDto crearConvenioDto)
        {
            try
            {
                await _convenioService.CrearConvenioAsync(crearConvenioDto);
                return CreatedAtAction(
                    nameof(Crear),
                    new Utils.SuccessResult<dynamic>(null, 201));
            }
            catch (Exception e)
            {
                return BadRequest(new Utils.BadResult(e.Message));
            }
            
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Editar(int id, EditarConvenioDto editarConvenioDto)
        {
            try
            {
                await _convenioService.EditarConvenioAsync(id, editarConvenioDto);
                return Ok(new Utils.SuccessResult<dynamic>(null));
            }
            catch (Exception e)
            {
                return BadRequest(new Utils.BadResult(e.Message));
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Eliminar(int id)
        {
            try{
                await _convenioService.EliminarConvenioAsync(id);
                return Ok(new Utils.SuccessResult<dynamic>(null));
            }
            catch (Exception e)
            {
                return BadRequest(new Utils.BadResult(e.Message));
            }
        }
    }
}
