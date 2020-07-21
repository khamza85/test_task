using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Synel.Web.Data;
using Synel.Web.Models;

namespace Synel.Web.Services
{
    public class QueryEmployeesHandler : IRequestHandler<QueryEmployees, Employee[]>
    {
        private readonly EmployeeContext _db;

        public QueryEmployeesHandler(EmployeeContext db)
        {
            _db = db;
        }

        public Task<Employee[]> Handle(QueryEmployees request)
        {
            var query = Filter(_db.Employees, request.Search);
            query = Sort(query, request.Sort);
            return query.AsNoTracking().ToArrayAsync();
        }

        private static IQueryable<Employee> Filter(IQueryable<Employee> query, string search) =>
            string.IsNullOrEmpty(search)
                ? query
                : from e in query
                where e.PayrollNo.Contains(search)
                      || e.FirstName.Contains(search)
                      || e.LastName.Contains(search)
                      || e.Telephone.Contains(search)
                      || e.MobilePhone.Contains(search)
                      || e.AddressLine1.Contains(search)
                      || e.AddressLine2.Contains(search)
                      || e.AddressPostalCode.Contains(search)
                      || e.Email.Contains(search)
                      // || e.BirthDate.ToString("d").Contains(search) TODO: Cannot be evaluated server-side
                      // || e.StartDate.ToString("d").Contains(search)
                select e;

        private static IQueryable<Employee> Sort(IQueryable<Employee> query, string sort) =>
            ParseSort(sort) switch
            {
                (nameof(Employee.PayrollNo), false) => query.OrderBy(_ => _.PayrollNo),
                (nameof(Employee.PayrollNo), true) => query.OrderByDescending(_ => _.PayrollNo),
                (nameof(Employee.FirstName), false) => query.OrderBy(_ => _.FirstName),
                (nameof(Employee.FirstName), true) => query.OrderByDescending(_ => _.FirstName),
                (nameof(Employee.LastName), false) => query.OrderBy(_ => _.LastName),
                (nameof(Employee.LastName), true) => query.OrderByDescending(_ => _.LastName),
                (nameof(Employee.BirthDate), false) => query.OrderBy(_ => _.BirthDate),
                (nameof(Employee.BirthDate), true) => query.OrderByDescending(_ => _.BirthDate),
                (nameof(Employee.Telephone), false) => query.OrderBy(_ => _.Telephone),
                (nameof(Employee.Telephone), true) => query.OrderByDescending(_ => _.Telephone),
                (nameof(Employee.MobilePhone), false) => query.OrderBy(_ => _.MobilePhone),
                (nameof(Employee.MobilePhone), true) => query.OrderByDescending(_ => _.MobilePhone),
                (nameof(Employee.AddressLine1), false) => query.OrderBy(_ => _.AddressLine1),
                (nameof(Employee.AddressLine1), true) => query.OrderByDescending(_ => _.AddressLine1),
                (nameof(Employee.AddressLine2), false) => query.OrderBy(_ => _.AddressLine2),
                (nameof(Employee.AddressLine2), true) => query.OrderByDescending(_ => _.AddressLine2),
                (nameof(Employee.AddressPostalCode), false) => query.OrderBy(_ => _.AddressPostalCode),
                (nameof(Employee.AddressPostalCode), true) => query.OrderByDescending(_ => _.AddressPostalCode),
                (nameof(Employee.Email), false) => query.OrderBy(_ => _.Email),
                (nameof(Employee.Email), true) => query.OrderByDescending(_ => _.Email),
                (nameof(Employee.StartDate), false) => query.OrderBy(_ => _.StartDate),
                (nameof(Employee.StartDate), true) => query.OrderByDescending(_ => _.StartDate),
                _ => query
            };

        private static (string key, bool desc) ParseSort(string sort) =>
            sort.EndsWith("_desc") ? (sort[..^5], true) : (sort, false);
    }
}