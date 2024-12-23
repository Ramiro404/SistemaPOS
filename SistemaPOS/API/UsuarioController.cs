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
        public async Task<IActionResult> Listar()
        {
            try
            {
                var data = await _usuarioService.ListarUsuarioDto();
                return Ok(new Utils.SuccessResult<List<UsuarioDto>>(data));
            }
            catch (Exception ex)
            {
                return BadRequest(new Utils.BadResult(ex.Message));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            try
            {
                var data = await _usuarioService.ObtenerUsuarioDtoPorId(id);
                return Ok(new Utils.SuccessResult<UsuarioDto>(data));
            }
            catch (Exception ex)
            {
                return BadRequest(new Utils.BadResult(ex.Message));
            }
        }

        [HttpPost]
        public async Task<ActionResult> Crear(CrearUsuarioDto crearUsuarioDto)
        {
            try
            {
                await _usuarioService.CrearUsuarioAsync(crearUsuarioDto);
                return Ok(new Utils.SuccessResult<dynamic>(null)); ;
            }
            catch (Exception ex)
            {
                return BadRequest(new Utils.BadResult(ex.Message));
            }
        }

            [HttpPatch("{id}")]
        public async Task<IActionResult> Editar(int id, EditarUsuarioDto editarUsuarioDto)
        {
            try
            {
                await _usuarioService.EditarUsuarioDto(id, editarUsuarioDto);
                return Ok(new Utils.SuccessResult<dynamic>(null)); ;
            }
            catch (Exception ex)
            {
                return BadRequest(new Utils.BadResult(ex.Message));
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Eliminar(int id)
        {
            try
            {
                await _usuarioService.EliminarUsuarioAsync(id);
                return Ok(new Utils.SuccessResult<dynamic>(null)); ;
            }
            catch (Exception ex)
            {
                return BadRequest(new Utils.BadResult(ex.Message));
            }
        }
    }
}
