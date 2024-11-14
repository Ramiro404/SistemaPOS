using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaPOS.Aplication.DTOs;
using SistemaPOS.Aplication.Services;
using SistemaPOS.Domain.Entities;

namespace SistemaPOS.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<List<UsuarioDto>> Listar()
        {
            return await _usuarioService.ListarUsuarioDto();
        }

        [HttpPost]
        public async Task<ActionResult> Crear(CrearUsuarioDto crearUsuarioDto)
        {
            await _usuarioService.CrearUsuarioAsync(crearUsuarioDto);
            return Created();
        }

        [HttpPatch("{id}")]
        public async Task Editar(int id, EditarUsuarioDto editarUsuarioDto)
        {
            await _usuarioService.EditarUsuarioDto(id, editarUsuarioDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Eliminar(int id)
        {
            await _usuarioService.EliminarUsuarioAsync(id);
            return Ok();
        }
    }
}
