namespace SistemaPOS.Domain.Repositories
{
    public interface InicioSesionRepository
    {
        public Task<int> Ingresar(string usuario, string password);
    }
}
