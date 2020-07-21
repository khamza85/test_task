using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Synel.Web.Data;
using Synel.Web.Models;

namespace Synel.Web.Services
{
    public class RemoveEmployeeHandler : IRequestHandler<RemoveEmployee, bool>
    {
        private readonly EmployeeContext _db;

        public RemoveEmployeeHandler(EmployeeContext db)
        {
            _db = db;
        }

        public async Task<bool> Handle(RemoveEmployee request)
        {
            _db.Entry(new Employee {Id = request.Id}).State = EntityState.Deleted;
            return await _db.SaveChangesAsync() > 0;
        }
    }
}