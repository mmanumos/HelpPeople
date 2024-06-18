using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HelpPeople.Generic;
using HelpPeople.Models.DTO;
using HelpPeople.Models.Filter;
using HelpPeople.Service.Contract;
using Microsoft.EntityFrameworkCore;
using System.Formats.Asn1;
using System.Globalization;
using HelpPeople.Models;
using CsvHelper;
using CsvHelper.Configuration;
using System.Reflection.PortableExecutable;

namespace HelpPeople.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ReadCsvController : Controller
    {

        #region fields
        private readonly IReadCvsService _readCvsService;
        #endregion

        public ReadCsvController(IReadCvsService readCvsService) {
            _readCvsService = readCvsService;
        }


        #region endpoints
        /// <summary>
        /// Carga nuevas personas
        /// </summary>
        /// <param name="file"</param>       
        /// <returns></returns>
        [HttpPost("upload")]
        public async Task<RequestResult<List<string>>> UploadCsv(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                //return BadRequest("No file uploaded.");
            }
                



            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                TrimOptions = TrimOptions.Trim
            };


            using (var reader = new StreamReader(file.OpenReadStream()))
            using (var csv = new CsvReader(reader, csvConfig))
            {
                var records = csv.GetRecords<DataRecordDto>().ToList();
                return await _readCvsService.UploadCsv(records);
            }

        }


        #endregion

    }
}
