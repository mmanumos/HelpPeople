using HelpPeople.Generic;
using HelpPeople.Models.DTO;
using HelpPeople.Models.Filter;

namespace HelpPeople.Service.Contract
{
    public interface IPersonaService
    {
        Task<RequestResult<List<PersonaDto>>> getPersonas(PersonaFilter personaFilter);
    }
}
