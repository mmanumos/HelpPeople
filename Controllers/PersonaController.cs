using Microsoft.AspNetCore.Mvc;
using HelpPeople.Service.Contract;
using HelpPeople.Generic;
using HelpPeople.Models.DTO;
using HelpPeople.Models.Filter;

namespace HelpPeople.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : Controller
    {
        #region fields
        private IPersonaService _personaService;
        #endregion

        #region builder
        public PersonaController(IPersonaService personaService) { 
            _personaService= personaService;
        }
        #endregion


        #region endpoints
        /// <summary>
        /// Obtiene las personas
        /// </summary>
        /// <param name="personaFilter"</param>       
        /// <returns></returns>
        [HttpPost]
        [Route(nameof(PersonaController.getPersonas))]

        //Se utiliza el async y el task para que toda la funcionalidad del endpoint funcione de manera asincrónica
        //Aunque también se combina con el await para que espere la respuesta antes de continuar el hilo
        public async Task<RequestResult<List<PersonaDto>>> getPersonas(PersonaFilter personaFilter)
        {
            return await _personaService.getPersonas(personaFilter);
        }
        #endregion

    }
}
