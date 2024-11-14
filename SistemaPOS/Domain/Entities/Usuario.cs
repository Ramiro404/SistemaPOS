namespace SistemaPOS.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public string ApellidoPaterno { get; private set; }
        public string ApellidoMaterno { get; private set; }
        public TimeSpan HoraEntrada { get; private set; }
        public TimeSpan HoraSalida { get; private set; }
        public DateTime? FechaInicioSesion {  get; private set; }
        public DateTime? FechaCierreSesion { get; private set; }
        public bool Eliminado { get; private set; } = false;

        public Usuario(string nombre, string apellidoPaterno, string apellidoMaterno, TimeSpan horaEntrada, TimeSpan horaSalida)
        {
            Nombre = nombre;
            ApellidoPaterno = apellidoPaterno;
            ApellidoMaterno = apellidoMaterno;
            HoraEntrada = horaEntrada;
            HoraSalida = horaSalida;
        }

        public Usuario(string nombre, string apellidoPaterno, string apellidoMaterno, TimeSpan horaEntrada, TimeSpan horaSalida, DateTime? fechaInicioSesion, DateTime? fechaCierreSesion)
        {
            Nombre = nombre;
            ApellidoPaterno = apellidoPaterno;
            ApellidoMaterno = apellidoMaterno;
            HoraEntrada = horaEntrada;
            HoraSalida = horaSalida;
            FechaInicioSesion = fechaInicioSesion;
            FechaCierreSesion = fechaCierreSesion;
        }

        public void Actualizar(string nombre, string apellidoPaterno, string apellidoMaterno, TimeSpan horaEntrada, TimeSpan horaSalida, DateTime? fechaInicioSesion, DateTime? fechaCierreSesion)
        {
            Nombre = nombre;
            ApellidoPaterno = apellidoPaterno;
            ApellidoMaterno = apellidoMaterno;
            HoraEntrada = horaEntrada;
            HoraSalida = horaSalida;
            FechaInicioSesion = fechaInicioSesion;
            FechaCierreSesion = fechaCierreSesion;
        }

        public void Eliminar()
        {
            Eliminado = true;
        }


    } 
}
