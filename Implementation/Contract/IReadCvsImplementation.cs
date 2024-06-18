using HelpPeople.Generic;
using HelpPeople.Models.DTO;

namespace HelpPeople.Implementation.Contract
{
    public interface IReadCvsImplementation
    {
        Task<bool> UploadCsv(List<DataRecordDto> dataRecords);
    }
}
