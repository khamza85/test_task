using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using Synel.Tests.Utils;
using Synel.Web.Data;
using Synel.Web.Models;
using Synel.Web.Services;
using Xunit;

namespace Synel.Tests.Services
{
    public class QueryEmployeesHandlerTests
    {
        [Theory, AutoDataWithMock]
        public async Task Sorts_MobilePhone_descending(
            [Frozen, Greedy] EmployeeContext db,
            Employee[] employees,
            QueryEmployees request,
            QueryEmployeesHandler sut)
        {
            await db.Employees.AddRangeAsync(employees);
            await db.SaveChangesAsync();
            request.Sort = nameof(Employee.MobilePhone) + "_desc";

            var result = await sut.Handle(request);

            result.Should().BeInDescendingOrder(_ => _.MobilePhone);
        }

        [Theory, AutoDataWithMock]
        public async Task Filters_whose_LastName_contains_string(
            [Frozen, Greedy] EmployeeContext db,
            Employee[] employees,
            QueryEmployees request,
            QueryEmployeesHandler sut)
        {
            employees[0].LastName = employees[0].LastName.Insert(10, request.Search);
            await db.Employees.AddRangeAsync(employees);
            await db.SaveChangesAsync();
            request.Sort = nameof(Employee.MobilePhone) + "_desc";

            var result = await sut.Handle(request);

            result.Should().ContainSingle()
                .Which.Should().BeEquivalentTo(employees[0]);
        }
    }
}