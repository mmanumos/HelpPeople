using HelpPeople.Models.Filter;
using HelpPeople.Models;

namespace HelpPeople.Implementation.Contract
{
    public interface IPersonaImplementation
    {
        Task<List<Persona>> getPersonas(PersonaFilter personaFilter);
    }
}
