using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class DTOs
    {
        public class GetAll
        {
            public int IdSolicitud { get; set; }
            public string? NombreUsuario { get; set; }
            public string? Email { get; set; }
            public string? Telefono { get; set; }
            public string? Mensaje { get; set; }
            public DateTime FechaSolicitud { get; set; }
            public string? Descripcion { get; set; }
        }
        public class DeleteSolicitud
        {
            public int IdSolicitud { get; set; }
        }
        public class SolicitudGetById
        {
            public int IdSolicitud { get; set; }
            public string? NombreUsuario { get; set; }
            public string? Email { get; set; }
            public string? Telefono { get; set; }
            public string? Mensaje { get; set; }
            public DateTime FechaSolicitud { get; set; }
            public string? Descripcion { get; set; }
        }
        public class ActualizarStatusSolicitud
        {
            public int IdSolicitud { get; set; }
            public int IdStatus { get; set; }
        }
    }
}
