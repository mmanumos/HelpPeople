using HelpPeople.Generic;
using HelpPeople.Implementation.Contract;
using HelpPeople.Models;
using HelpPeople.Models.DTO;
using HelpPeople.Models.Filter;
using Microsoft.EntityFrameworkCore;


namespace HelpPeople.Implementation
{
    public class ReadCsvImplementation: IReadCvsImplementation
    {
        #region fields
        private readonly HelpPeopleContext _context;
        #endregion

        #region builder
        public ReadCsvImplementation(HelpPeopleContext context)
        {
            _context = context;
        }
        #endregion



        #region methods
        public async Task<bool> UploadCsv(List<DataRecordDto> dataRecords)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    foreach (var record in dataRecords)
                    {
                        Persona persona = new Persona();
                        persona.Nombre = record.Nombre;
                        persona.Apellido = record.Apellido;
                        persona.CorreoElectronico = record.CorreoElectronico;
                        persona.TipoDocumento= record.TipoDocumento;
                        persona.NroDocumento= record.NroDocumento;

                        _context.Add(persona);
                        await _context.SaveChangesAsync();

                        
                    }

                    transaction.Commit(); // Confirma la transacción si todo ha ido bien

                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return false;
                }
            }

        }
        #endregion
    }
}
