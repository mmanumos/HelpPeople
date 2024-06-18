namespace HelpPeople.Models.DTO
{
    public class PersonaDto
    {
        public int IdPersona { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? TipoDocumento { get; set; }
        public int NroDocumento { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
