using Microsoft.EntityFrameworkCore;
using SistemaPOS.Aplication.DTOs;
using SistemaPOS.Domain.Entities;
using SistemaPOS.Domain.Repositories;
using SistemaPOS.Infrastructure.Persistence;
using System;

namespace SistemaPOS.Infrastructure.Data
{
    public class ProductoRepositoryImpl : ProductoRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductoRepositoryImpl(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CrearProducto(Producto producto)
        {
            string productoNombre = producto.Nombre.ToLower();
            var productoExiste = await _context.Productos.Where(p => p.Nombre.ToLower() == productoNombre).SingleOrDefaultAsync();
            if(productoExiste is not null)
            {
                throw new Exception("Este producto ya esta registrado");
            }
            await _context.Productos.AddAsync(producto);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarProducto(int productoId)
        {
            var producto = await _context.Productos.Where(p => p.Id.Equals(productoId)).FirstOrDefaultAsync();
            if(producto != null)
            {
                EsProductoEliminado(producto.Eliminado);
                producto.EliminarProducto();
                _context.Entry(producto).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("No encontrado");
            }
        }

        public async Task<Producto> EditarProducto(int id, Producto producto)
        {

            var nuevoProducto = await _context.Productos.Where(p => p.Id.Equals(id)).FirstOrDefaultAsync();

            if(nuevoProducto != null)
            {
                EsProductoEliminado(nuevoProducto.Eliminado);

                nuevoProducto.Actualizar(
                    producto.Nombre,
                    producto.ValorUnitario,
                    producto.Medida,
                    producto.UnidadMedida,
                    producto.Peso,
                    producto.VolumenEmpaque);
                _context.Entry(nuevoProducto).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return nuevoProducto;
            }
            throw new Exception("Producto no encontrado");
        }

        public async Task<Producto> ObtenerProductoPorId(int id)
        {
            var data =  await _context.Productos.FindAsync(id);
            if(data != null)
            {
                return data;
            }
            throw new Exception("No se encontro el producto");
        } 

        public async Task<List<ProductoDto>> ListarProductos()
        {
            return await (
                from p in _context.Productos
                where !p.Eliminado
                select new ProductoDto
                {
                    Id = p.Id,
                    Medida = p.Medida,
                    Nombre = p.Nombre,
                    Peso = p.Peso,
                    UnidadMedida = p.UnidadMedida,
                    ValorUnitario = p.ValorUnitario,
                    VolumenEmpaque = p.VolumenEmpaque,
                    Stock = p.Stock,
                }).ToListAsync();
        }

        public void EsProductoEliminado(bool eliminado)
        {
            if(eliminado)
            {
                throw new Exception("Producto esta eliminado");
            }
        }

        public async Task IngresarInventario(int  productoId, int cantidad)
        {
            var producto = await _context.Productos.FindAsync(productoId);
            if(producto == null)
            {
                throw new Exception("No se encontro el producto");
            }
            producto.IngresarInventario(cantidad);
            _context.Entry(producto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DescontarInventario(int productoId, int cantidad)
        {
            var producto = await _context.Productos.FindAsync(productoId);
            if (producto == null) throw new Exception("No se encontro el producto");
            producto.DescontarInventario(cantidad);
            _context.Entry(producto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
