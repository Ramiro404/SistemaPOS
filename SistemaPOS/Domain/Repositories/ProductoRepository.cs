using SistemaPOS.Aplication.DTOs;
using SistemaPOS.Domain.Entities;

namespace SistemaPOS.Domain.Repositories
{
    public interface ProductoRepository
    {
        Task CrearProducto(Producto producto);
        Task<Producto> EditarProducto(Producto producto);
        Task EliminarProducto(int productoId);
        Task<List<ProductoDto>> ListarProductos();
        Task IngresarInventario(int productoId, int cantidad);
        Task DescontarInventario(int productoId, int cantidad);
    }
}
