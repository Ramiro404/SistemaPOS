using SistemaPOS.Aplication.DTOs;
using SistemaPOS.Domain.Entities;
using SistemaPOS.Domain.Repositories;

namespace SistemaPOS.Aplication.Services
{
    public class ConvenioService
    {
        private readonly ConvenioRepository _convenioRepository;

        public ConvenioService(ConvenioRepository convenioRepository)
        {
            _convenioRepository = convenioRepository;
        }

        public async Task CrearConvenioAsync(CrearConvenioDto crearConvenioDto)
        {
            Convenio convenio = new Convenio(
                crearConvenioDto.Nombre,
                crearConvenioDto.Descripcion,
                crearConvenioDto.PorcentajeDescuento);
            await _convenioRepository.CrearConvenio(convenio);
        }

        public async Task EditarConvenioAsync(int id, EditarConvenioDto editarConvenioDto)
        {
            Convenio convenio = new Convenio(
                editarConvenioDto.Nombre,
                editarConvenioDto.Descripcion,
                editarConvenioDto.PorcentajeDescuento);
            await _convenioRepository.EditarConvenio(id, convenio);
        }

        public async Task EliminarConvenioAsync(int id)
        {
            await _convenioRepository.EliminarConvenio(id);
        }
        public async Task<List<ConvenioDto>> ListarConvenioAsync()
        {
            var lista = await _convenioRepository.ListarConvenio();
            return lista.Select(c => new ConvenioDto { 
                Id = c.Id,
                Descripcion = c.Descripcion,
                Nombre = c.Nombre,
                PorcentajeDescuento = c.PorcentajeDescuento
            }).ToList();
        }
    }
}
