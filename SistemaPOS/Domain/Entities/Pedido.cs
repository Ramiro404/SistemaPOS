namespace SistemaPOS.Domain.Entities
{
    public class Pedido
    {
        public int Id { get; private set; }
        public DateTime FechaCreacion { get; private set; }
        public DateTime? FechaActualizacion { get; private set; }
        public DateTime? FechaFacturacion { get; private set; }
        public DateTime? FechaCierre { get; private set; }
        public int Cantidad { get; private set; }
        public bool Eliminado { get; private set; } = false;
        public int ClienteId { get; private set; }
        public Cliente Cliente { get; private set; }
        //public List<Producto> Productos { get; private set; }
        public int ProductoId { get; private set; }
        public Producto Producto { get; private set; }


        public Pedido() { }

        public Pedido(int clienteId, int productoId, int cantidad)
        {
            FechaCreacion = DateTime.Now;
            ClienteId = clienteId;
            ProductoId = productoId;
            Cantidad = cantidad;
        }



        public void Actualizar(List<Producto> productos)
        {
            //Productos = productos;
            throw new NotImplementedException();
        }

        public void Cerrar()
        {
            FechaCierre = DateTime.Now;
        }
    }
}
