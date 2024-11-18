using Microsoft.EntityFrameworkCore;
using SistemaPOS.Domain.Entities;

namespace SistemaPOS.Infrastructure.Persistence
{
    public class ApplicationDbContext: DbContext
    {

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Convenio> Convenios { get; set; }
        public DbSet<PedidoFactura> PedidosFactura { get; set; }
        public DbSet<MedioPago> MedioPagos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Producto)
                .WithMany(p => p.Pedidos)
                .HasForeignKey(p => p.ProductoId);

            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Cliente)
                .WithMany(p => p.Pedidos)
                .HasForeignKey(p => p.ClienteId);*/
        }

    }
}
