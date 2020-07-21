using System;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Synel.Tests.Utils;
using Synel.Web.Data;
using Synel.Web.Models;
using Synel.Web.Services;
using Xunit;

namespace Synel.Tests.Services
{
    public class SaveEmployeeHandlerTests
    {
        [Theory, AutoDataWithMock]
        public async Task Creates_employee(
            [Frozen, Greedy] EmployeeContext db,
            SaveEmployee request,
            SaveEmployeeHandler sut)
        {
            request.Value.Id = Guid.Empty;

            var success = await sut.Handle(request);

            success.Should().BeTrue();
            request.Value.Id.Should().NotBe(Guid.Empty);
            db.Employees.Find(request.Value.Id).Should().BeEquivalentTo(request.Value);
        }

        [Theory, AutoDataWithMock]
        public async Task Updates_employee(
            [Frozen, Greedy] EmployeeContext db,
            Employee existingEmployee,
            SaveEmployee request,
            SaveEmployeeHandler sut)
        {
            await db.Employees.AddAsync(existingEmployee);
            await db.SaveChangesAsync();
            db.Entry(existingEmployee).State = EntityState.Detached;
            request.Value.Id = existingEmployee.Id;

            var success = await sut.Handle(request);

            success.Should().BeTrue();
            var updatedEmployee = db.Find<Employee>(existingEmployee.Id);
            updatedEmployee.Should().BeEquivalentTo(request.Value);
            updatedEmployee.Should().NotBeEquivalentTo(existingEmployee);
        }
    }
}