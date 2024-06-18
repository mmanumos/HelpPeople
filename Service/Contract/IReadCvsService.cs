using HelpPeople.Generic;
using HelpPeople.Models.DTO;
using HelpPeople.Models.Filter;

namespace HelpPeople.Service.Contract
{
    public interface IReadCvsService
    {
        Task<RequestResult<List<string>>> UploadCsv(List<DataRecordDto> dataRecords);
    }
}
