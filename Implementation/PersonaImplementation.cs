using HelpPeople.Implementation.Contract;
using HelpPeople.Models;
using HelpPeople.Models.Filter;
using Microsoft.EntityFrameworkCore;

namespace HelpPeople.Implementation
{
    public class PersonaImplementation: IPersonaImplementation
    {
        #region fields
        private readonly HelpPeopleContext _context;
        #endregion

        #region builder
        public PersonaImplementation(HelpPeopleContext context)
        {
            _context = context;
        }
        #endregion

        #region methods
        public async Task<List<Persona>> getPersonas(PersonaFilter personaFilter)
        {
            try
            {
                if (personaFilter.IdPersona > 0)
                {
                    return await _context.Personas.Where(x => x.IdPersona == personaFilter.IdPersona).ToListAsync();
                }
                if (personaFilter.NroDocumento > 0)
                {
                    return await _context.Personas.Where(x => x.NroDocumento == personaFilter.NroDocumento).ToListAsync();
                }
                if (personaFilter.Nombre != "")
                {
                    return await _context.Personas.Where(x => x.Nombre == personaFilter.Nombre).ToListAsync();
                }
                if (personaFilter.Apellido != "")
                {
                    return await _context.Personas.Where(x => x.Apellido == personaFilter.Apellido).ToListAsync();
                }
                if (personaFilter.CorreoElectronico != "")
                {
                    return await _context.Personas.Where(x => x.CorreoElectronico == personaFilter.CorreoElectronico).ToListAsync();
                }

                else
                {
                    return await _context.Personas.ToListAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                //Cierre de conexión a la base de datos
                _context.Dispose();
            }
        }
        #endregion




    }
}
