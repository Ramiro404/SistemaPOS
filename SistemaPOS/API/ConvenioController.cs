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
        public async Task<List<ConvenioDto>> Listar()
        {
            return await _convenioService.ListarConvenioAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Crear(CrearConvenioDto crearConvenioDto)
        {
            await _convenioService.CrearConvenioAsync(crearConvenioDto);
            return Created();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Editar(int id, EditarConvenioDto editarConvenioDto)
        {
            await _convenioService.EditarConvenioAsync(id, editarConvenioDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Eliminar(int id)
        {
            await _convenioService.EliminarConvenioAsync(id);
            return Ok();
        }
    }
}
