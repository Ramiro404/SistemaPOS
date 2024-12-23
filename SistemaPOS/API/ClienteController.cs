using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SistemaPOS.Aplication.DTOs;
using SistemaPOS.Aplication.Services;
using SistemaPOS.Domain.Entities;
using SistemaPOS.Utils;

namespace SistemaPOS.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private ClienteService _clienteService;

        public ClienteController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            try
            {
                var data = await _clienteService.ListarClienteAsync();
                return Ok(new Utils.SuccessResult<List<ClienteDto>>(data));
            }catch(Exception ex) {

                return BadRequest(new Utils.BadResult(ex.Message));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Crear(CrearClienteDto crearClienteDto)
        {

            try
            {
                await _clienteService.CrearClienteAsync(crearClienteDto);
                return CreatedAtAction(
                    nameof(Crear),
                    new Utils.SuccessResult<dynamic>(null, 201));

            }catch(Exception ex)
            {
                return BadRequest(new Utils.BadResult(ex.Message));
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Editar(int id, EditarClienteDto editarClienteDto)
        {
            try
            {
                var data =  await _clienteService.EditarClienteAsync(id, editarClienteDto);
                return Ok(new Utils.SuccessResult<Cliente>(data));

            }catch(Exception ex)
            {
                return BadRequest(new Utils.BadResult(ex.Message));
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Eliminar(int id)
        {
            try
            {
                await _clienteService.EliminarClienteAsync(id);
                return Ok(new Utils.SuccessResult<dynamic>(null));
            }catch(Exception e)
            {
                return BadRequest(new Utils.BadResult(e.Message));
            }
        }
    }
}
