namespace SistemaPOS.Domain.Entities
{
    public class Producto
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public Decimal ValorUnitario { get; private set; }
        public float Medida { get; private set; }
        public string UnidadMedida { get; private set; }
        public float Peso { get; private set; }
        public float VolumenEmpaque { get; private set; }
        public DateTime FechaCreacion { get; private set; }
        public DateTime? FechaActualizacion { get; private set; }
        public int Stock {  get; private set; }
        public bool Eliminado { get; private set; }


        public Producto() { }

        public Producto(string nombre, decimal valorUnitario, float medida, string unidadMedida, float peso, float volumenEmpaque)
        {
            Nombre = nombre;
            ValorUnitario = valorUnitario;
            Medida = medida;
            UnidadMedida = unidadMedida;
            Peso = peso;
            VolumenEmpaque = volumenEmpaque;
            FechaCreacion = DateTime.Now.ToUniversalTime();
            Stock = 0;
            Eliminado = false;
        }
        
        public void EstablecerId(int id)
        {
            this.Id = id;
        }

        public void IngresarInventario(int stock)
        {
            if (!this.Eliminado) throw new Exception("Este producto esta eliminado");
            if (stock < 0) throw new ArgumentOutOfRangeException("No ingresar numeros negativos");
            this.Stock += stock;
        }

        public void DescontarInventario(int stock)
        {
            if (!this.Eliminado) throw new Exception("Este producto esta eliminado");
            if (stock < 0) throw new ArgumentOutOfRangeException("No ingresar numeros negativos");
            if(this.Stock < stock) throw new Exception("No puedes descontar la cantidad permitida");
            this.Stock -= stock;
        }

        public void EliminarProducto()
        {
            this.Eliminado = true;
        }

        public void Actualizar(string nombre, decimal valorUnitario, float medida, string unidadMedida, float peso, float volumenEmpaque)
        {
            Nombre = nombre;
            ValorUnitario = valorUnitario;
            Medida = medida;
            UnidadMedida = unidadMedida;
            Peso = peso;
            VolumenEmpaque = volumenEmpaque;
            FechaActualizacion = DateTime.Now.ToUniversalTime();
        }
    }
}
