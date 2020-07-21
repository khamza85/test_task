using CsvHelper.Configuration;
using Synel.Web.Models;

namespace Synel.Web.Services
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class EmployeeCsvMap : ClassMap<Employee>
    {
        public EmployeeCsvMap()
        {
            Map(_ => _.PayrollNo).Index(0);
            Map(_ => _.FirstName).Index(1);
            Map(_ => _.LastName).Index(2);
            Map(_ => _.BirthDate).Index(3);
            Map(_ => _.Telephone).Index(4);
            Map(_ => _.MobilePhone).Index(5);
            Map(_ => _.AddressLine1).Index(6);
            Map(_ => _.AddressLine2).Index(7);
            Map(_ => _.AddressPostalCode).Index(8);
            Map(_ => _.Email).Index(9);
            Map(_ => _.StartDate).Index(10);
        }
    }
}