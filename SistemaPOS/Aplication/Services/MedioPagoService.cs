using SistemaPOS.Aplication.DTOs;
using SistemaPOS.Domain.Entities;
using SistemaPOS.Domain.Repositories;

namespace SistemaPOS.Aplication.Services
{
    public class MedioPagoService
    {
        private readonly MedioPagoRepository _medioPagoRepository;

        public MedioPagoService(MedioPagoRepository medioPagoRepository)
        {
            _medioPagoRepository = medioPagoRepository;
        }
        public async Task CrearMedioPagoAsync(CrearMedioPagoDto crearMedioPagoDto)
        {
            MedioPago medioPago = new MedioPago(
                crearMedioPagoDto.Nombre,
                crearMedioPagoDto.Descripcion);
            await _medioPagoRepository.CrearMedioPago(medioPago);
        }

        public async Task EditarMedioPagoAsync(int id, EditarMedioPago editarMedioPago)
        {
            MedioPago medioPago = new MedioPago(
                editarMedioPago.Nombre,
                editarMedioPago.Descripcion);
            await _medioPagoRepository.EditarMedioPago(id, medioPago);
        }
        public async Task EliminarMedioPagoAsync(int id)
        {
            await _medioPagoRepository.EliminarMedioPago(id);
        }

        public async Task<List<MedioPagoDto>> ListarMedioPagoAsync()
        {
           var lista = await _medioPagoRepository.ListarMedioPago();
           return lista.Select(mp => new MedioPagoDto
            {
                Id = mp.Id,
                Descripcion = mp.Descripcion,
                Nombre = mp.Nombre,
            }).ToList();
        }
    }
}
