namespace SistemaPOS.Domain.Entities
{
    public class MedioPago
    {

        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public string Descripcion { get; private set; }
        public DateTime FechaCreacion { get; private set; }
        public DateTime? FechaActualizacion { get; private set; }
        public bool Eliminado { get; private set; }

        public MedioPago(string nombre, string descripcion)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            FechaCreacion = DateTime.Now;
        }

        public void Actualizar(string nombre, string descripcion)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            FechaActualizacion = DateTime.Now;
        }

        public void Eliminar()
        {
            Eliminado = true;
        }
    }
}
