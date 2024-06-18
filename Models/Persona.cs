using System;
using System.Collections.Generic;

namespace HelpPeople.Models;

public partial class Persona
{
    public long IdPersona { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string CorreoElectronico { get; set; } = null!;

    public string? TipoDocumento { get; set; }

    public int NroDocumento { get; set; }

    public DateTime FechaRegistro { get; set; }
}
