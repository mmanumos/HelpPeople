using AutoMapper;
using HelpPeople.Generic;
using HelpPeople.Implementation.Contract;
using HelpPeople.Models;
using HelpPeople.Models.DTO;
using HelpPeople.Models.Filter;
using HelpPeople.Service.Contract;
using System.Collections.Generic;

namespace HelpPeople.Service.Contract
{
    public class ReadCvsService: IReadCvsService
    {

        #region fields
        private readonly IMapper _mapper;
        private readonly IReadCvsImplementation _readCvsImplementation;
        #endregion


        #region builder
        public ReadCvsService(IMapper mapper,IReadCvsImplementation readCvsImplementation)
        {
            _mapper = mapper;
            _readCvsImplementation= readCvsImplementation;
        }
        #endregion

        public async Task<RequestResult<List<string>>> UploadCsv(List<DataRecordDto> dataRecords)
        {
            List<DataRecordDto> lista_bien= new List<DataRecordDto>();
            List<string> lista_resultado = new List<string>();

            int x = 0;
            foreach (DataRecordDto dataRecord in dataRecords)
            {
                bool bien = true;
                if (string.IsNullOrEmpty(dataRecord.Nombre))
                {
                    lista_resultado.Add($"Error en la fila {x} : Columna Nombre.");
                    x++;
                    bien = false;
                }

                if (string.IsNullOrEmpty(dataRecord.Apellido))
                {
                    lista_resultado.Add($"Error en la fila {x} : Columna Apellido.");
                    x++;
                    bien = false;
                }

                if (string.IsNullOrEmpty(dataRecord.CorreoElectronico))
                {
                    lista_resultado.Add($"Error en la fila {x} : Columna CorreoElectronico.");
                    x++;
                    bien = false;
                }

                if (string.IsNullOrEmpty(dataRecord.TipoDocumento))
                {
                    lista_resultado.Add($"Error en la fila {x} : Columna TipoDocumento.");
                    x++;
                    bien = false;
                }

                if (dataRecord.NroDocumento < 1)
                {
                    lista_resultado.Add($"Error en la fila {x} : Columna NroDocumento.");
                    x++;
                    bien = false;
                }

                if (bien)
                {
                    lista_bien.Add(dataRecord);
                }
                
            }
            
            var result = await _readCvsImplementation.UploadCsv(lista_bien);

            if (result)
            {
                lista_resultado.Insert(0, $"Se crearon {lista_bien.Count()} registros en la base de datos.");
                lista_resultado.Insert(0, $"{lista_bien.Count()} registros del archivo cumplieron con las condiciones para ser guardados en base de datos.");
                lista_resultado.Insert(0, $"Total registros: {dataRecords.Count()}.");
                return RequestResult<List<string>>.CreateSuccesful(lista_resultado, HelpPeopleMessages.SUCCES001);
            }
            else
            {
                lista_resultado.Add("Error: No se pudieron crear los registros al insertar en la base de datos");
                return RequestResult<List<string>>.CreateSuccesful(lista_resultado, HelpPeopleMessages.SUCCES001);
            }
        }
    }
}
