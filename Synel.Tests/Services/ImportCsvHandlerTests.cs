using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using CsvHelper;
using FluentAssertions;
using Moq;
using Synel.Tests.Utils;
using Synel.Web.Models;
using Synel.Web.Services;
using Xunit;

namespace Synel.Tests.Services
{
    public class ImportCsvHandlerTests
    {
        [Theory, AutoDataWithMock]
        public async Task Returns_number_of_rows_imported_and_saved_to_db(
            Employee[] employees,
            ImportCsv request,
            ImportCsvHandler sut)
        {
            var stream = new MemoryStream();
            await using var streamWriter = new StreamWriter(stream, leaveOpen: true);
            await using var csvWriter = new CsvWriter(streamWriter, CultureInfo.GetCultureInfo("en-GB"));
            csvWriter.Configuration.RegisterClassMap<EmployeeCsvMap>();
            await csvWriter.WriteRecordsAsync(employees);
            await streamWriter.FlushAsync();
            stream.Position = 0;
            Mock.Get(request.Csv).Setup(_ => _.OpenReadStream()).Returns(stream);

            var rows = await sut.Handle(request);

            rows.Should().Be(employees.Length);
        }

        [Theory, AutoDataWithMock]
        public async Task Returns_zero_when_csv_is_null(
            ImportCsv request,
            ImportCsvHandler sut)
        {
            request.Csv = null;
            var rows = await sut.Handle(request);
            rows.Should().Be(0);
        }

    }
}