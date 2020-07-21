using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using CsvHelper;
using Synel.Web.Data;
using Synel.Web.Models;

namespace Synel.Web.Services
{
    public class ImportCsvHandler : IRequestHandler<ImportCsv, int>
    {
        private readonly EmployeeContext _db;

        public ImportCsvHandler(EmployeeContext db)
        {
            _db = db;
        }

        public async Task<int> Handle(ImportCsv request)
        {
            if (request.Csv == null) return 0;

            using var streamReader = new StreamReader(request.Csv.OpenReadStream());
            using var csvReader = new CsvReader(streamReader, CultureInfo.GetCultureInfo("en-GB"));

            csvReader.Configuration.RegisterClassMap<EmployeeCsvMap>();
            var employees = csvReader.GetRecords<Employee>();
            await _db.AddRangeAsync(employees);
            return await _db.SaveChangesAsync();
        }
    }
}