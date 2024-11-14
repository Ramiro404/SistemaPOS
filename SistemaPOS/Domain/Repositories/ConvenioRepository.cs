using SistemaPOS.Domain.Entities;

namespace SistemaPOS.Domain.Repositories
{
    public interface ConvenioRepository
    {
        public Task CrearConvenio(Convenio convenio);
        public Task<Convenio> EditarConvenio(int id, Convenio convenio);
        public Task EliminarConvenio(int id);
        public Task<List<Convenio>> ListarConvenio();

    }
}
