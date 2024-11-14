using SistemaPOS.Aplication.DTOs;
using SistemaPOS.Domain.Entities;
using SistemaPOS.Domain.Repositories;

namespace SistemaPOS.Aplication.Services
{
    public class ProductoService
    {
        private readonly ProductoRepository _productoRepository;

        public ProductoService(ProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task CrearProductoAsync(CrearProductoDto crearProductoDto)
        {
            var producto = new Producto(
                crearProductoDto.Nombre,
                crearProductoDto.ValorUnitario,
                crearProductoDto.Medida,
                crearProductoDto.UnidadMedida,
                crearProductoDto.Peso,
                crearProductoDto.VolumenEmpaque);
            await _productoRepository.CrearProducto(producto);

        }

        public async Task EditarProductoAsync(EditarProductoDto editarProductoDto)
        {
            var producto = new Producto(
                editarProductoDto.Nombre,
                editarProductoDto.ValorUnitario,
                editarProductoDto.Medida,
                editarProductoDto.UnidadMedida,
                editarProductoDto.Peso,
                editarProductoDto.VolumenEmpaque);
            producto.EstablecerId(editarProductoDto.Id);
            await _productoRepository.EditarProducto(producto);
        }

        public async Task EliminarProductoAsync(int id)
        {
            await _productoRepository.EliminarProducto(id);
        }

        public async Task<List<ProductoDto>> ListarProductoAsync()
        {
            return await _productoRepository.ListarProductos();
        }

        public async Task IngresarInventarioAsync(int productoId, int cantidad)
        {
            await _productoRepository.IngresarInventario(productoId, cantidad);
        }

        public async Task DescontarInventarioAsync(int productoId, int cantidad)
        {
            await _productoRepository.DescontarInventario(productoId, cantidad);
        }
    }
}
