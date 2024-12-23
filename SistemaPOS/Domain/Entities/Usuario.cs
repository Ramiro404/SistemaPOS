namespace SistemaPOS.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public string ApellidoPaterno { get; private set; }
        public string ApellidoMaterno { get; private set; }
        public TimeOnly HoraEntrada { get; private set; }
        public TimeOnly HoraSalida { get; private set; }
        public string User {  get; private set; }
        public string Password { get; private set; }
        public DateTime? FechaInicioSesion {  get; private set; }
        public DateTime? FechaCierreSesion { get; private set; }
        public bool Eliminado { get; private set; } = false;

        public Usuario(string nombre, string apellidoPaterno, string apellidoMaterno, TimeOnly horaEntrada, TimeOnly horaSalida)
        {
            Nombre = nombre;
            ApellidoPaterno = apellidoPaterno;
            ApellidoMaterno = apellidoMaterno;
            HoraEntrada = horaEntrada;
            HoraSalida = horaSalida;
        }

        public Usuario(string nombre, string apellidoPaterno, string apellidoMaterno, string usuario, string password, TimeOnly horaEntrada, TimeOnly horaSalida, DateTime? fechaInicioSesion, DateTime? fechaCierreSesion)
        {
            Nombre = nombre;
            ApellidoPaterno = apellidoPaterno;
            ApellidoMaterno = apellidoMaterno;
            HoraEntrada = horaEntrada;
            HoraSalida = horaSalida;
            User = usuario;
            Password = password;
            FechaInicioSesion = fechaInicioSesion;
            FechaCierreSesion = fechaCierreSesion;
        }



        public void Actualizar(string nombre, string apellidoPaterno, string apellidoMaterno, TimeOnly horaEntrada, TimeOnly horaSalida, DateTime? fechaInicioSesion, DateTime? fechaCierreSesion)
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

        public void RegistrarIngreso()
        {
            FechaInicioSesion = DateTime.Now;
        }

        public void RegistrarSalida()
        {
            FechaCierreSesion = DateTime.Now;
        }


    } 
}
