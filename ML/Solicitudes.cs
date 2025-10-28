namespace ML
{
    public class Solicitudes
    {
        public int IdSolicitud { get; set; }

        public string? NombreUsuario { get; set; }

        public string? Email { get; set; }

        public string? Telefono { get; set; }

        public string? Mensaje { get; set; }

        public DateTime? FechaSolicitud { get; set; }

        public ML.StatusSolicitudes? StatusSolicitudes { get; set; }

    }
}
