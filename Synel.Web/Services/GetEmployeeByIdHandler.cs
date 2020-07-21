using System.Threading.Tasks;
using Synel.Web.Data;
using Synel.Web.Models;

namespace Synel.Web.Services
{
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeById, Employee>
    {
        private readonly EmployeeContext _db;

        public GetEmployeeByIdHandler(EmployeeContext db)
        {
            _db = db;
        }

        public Task<Employee> Handle(GetEmployeeById request) => _db.Employees.FindAsync(request.Id).AsTask();
    }
}