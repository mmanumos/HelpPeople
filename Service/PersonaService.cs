using AutoMapper;
using HelpPeople.Generic;
using HelpPeople.Implementation.Contract;
using HelpPeople.Models;
using HelpPeople.Models.DTO;
using HelpPeople.Models.Filter;
using HelpPeople.Service.Contract;

namespace HelpPeople.Service
{
    public class PersonaService : IPersonaService
    {
        #region fields
        private readonly IMapper _mapper;
        private readonly IPersonaImplementation _personaImplementation;
        #endregion

        #region builder
        public PersonaService(IPersonaImplementation personaImplementation, IMapper mapper)
        {
            _personaImplementation = personaImplementation;
            _mapper = mapper;
        }
        #endregion


        #region methods
        public async Task<RequestResult<List<PersonaDto>>> getPersonas(PersonaFilter personaFilter)
        {
            //Validations
            try
            {
                var result = await _personaImplementation.getPersonas(personaFilter);
                var resultMap = _mapper.Map<List<Persona>, List<PersonaDto>>(result);
                return RequestResult<List<PersonaDto>>.CreateSuccesful(resultMap, HelpPeopleMessages.SUCCES001);
                
            }
            catch (Exception ex)
            {

                return RequestResult<List<PersonaDto>>.CreateError(HelpPeopleMessages.ERROR001);
            }

        }




        #endregion

    }
}
