using System.Linq;
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
    public class GetEmployeeByIdHandlerTests
    {
        [Theory, AutoDataWithMock]
        public async Task Returns_null_when_no_match(
            [Frozen, Greedy] EmployeeContext db,
            Employee[] employees,
            GetEmployeeById request,
            GetEmployeeByIdHandler sut) // SUT - System Under Test https://docs.microsoft.com/en-us/archive/blogs/ploeh/naming-sut-test-variables
        {
            await db.Employees.AddRangeAsync(employees);
            await db.SaveChangesAsync();

            var employee = await sut.Handle(request);

            employee.Should().BeNull();
        }

        [Theory, AutoDataWithMock]
        public async Task Returns_matched_employee(
            [Frozen, Greedy] EmployeeContext db,
            Employee[] employees,
            GetEmployeeById request,
            GetEmployeeByIdHandler sut)
        {
            request.Id = employees[0].Id;
            await db.Employees.AddRangeAsync(employees);
            await db.SaveChangesAsync();

            var employee = await sut.Handle(request);

            employee.Should().BeEquivalentTo(employees[0]);
        }
    }
}