using System;
using System.Collections.Generic;

namespace DL;

public partial class Solicitude
{
    public int IdSolicitud { get; set; }

    public string? NombreUsuario { get; set; }

    public string? Email { get; set; }

    public string? Telefono { get; set; }

    public string? Mensaje { get; set; }

    public DateTime? FechaSolicitud { get; set; }

    public int? IdStatus { get; set; }

    public virtual StatusSolicitude? IdStatusNavigation { get; set; }
}
