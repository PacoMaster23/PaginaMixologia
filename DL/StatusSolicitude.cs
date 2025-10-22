using System;
using System.Collections.Generic;

namespace DL;

public partial class StatusSolicitude
{
    public int IdStatus { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Solicitude> Solicitudes { get; set; } = new List<Solicitude>();
}
