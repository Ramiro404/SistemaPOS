namespace SistemaPOS.Domain.Entities
{
    public class Convenio
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public string Descripcion { get; private set; }
        public int PorcentajeDescuento { get; private set; }
        public DateTime FechaCreacion { get; private set; }
        public DateTime? FechaActualizacion { get; private set; }
        public bool Eliminado { get; private set; } = false;

        public Convenio(string nombre, string descripcion, int porcentajeDescuento)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            PorcentajeDescuento = porcentajeDescuento;
            FechaCreacion = DateTime.Now;
        }

        public void Actualizar(string nombre, string descripcion, int porcentajeDescuento)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            PorcentajeDescuento = porcentajeDescuento;
            FechaActualizacion = DateTime.Now;
        }

        public void Eliminar()
        {
            Eliminado = true;
        }
    }


}
