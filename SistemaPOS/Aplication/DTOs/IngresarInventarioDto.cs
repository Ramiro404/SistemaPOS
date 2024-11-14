namespace SistemaPOS.Aplication.DTOs
{
    public class IngresarInventarioDto
    {
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
    }

    public class DescontarInventarioDto: IngresarInventarioDto { }
}
