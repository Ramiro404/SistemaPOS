using SistemaPOS.Domain.Entities;

namespace SistemaPOS.Domain.Repositories
{
    public interface MedioPagoRepository
    {
        public Task CrearMedioPago(MedioPago medioPago);
        public Task EditarMedioPago(int id, MedioPago medioPago);
        public Task EliminarMedioPago(int id);
        public Task<List<MedioPago>> ListarMedioPago();

    }
}
