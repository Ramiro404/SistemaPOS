using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaPOS.Aplication.DTOs;
using SistemaPOS.Aplication.Services;
using SistemaPOS.Domain.Entities;

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
        public async Task<List<ClienteDto>> Listar()
        {
            return await _clienteService.ListarClienteAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Crear(CrearClienteDto crearClienteDto)
        {
            await _clienteService.CrearClienteAsync(crearClienteDto);
            return Created();
        }

        [HttpPatch("{id}")]
        public async Task<Cliente> Editar(int id, EditarClienteDto editarClienteDto)
        {
            return await _clienteService.EditarClienteAsync(id, editarClienteDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Eliminar(int id)
        {
            await _clienteService.EliminarClienteAsync(id);
            return Ok();
        }
    }
}
