namespace HelpPeople.Models.Filter
{
    public class PersonaFilter
    {
        public int IdPersona { get; set; }
        public int NroDocumento { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? CorreoElectronico { get; set; }
    }
}
