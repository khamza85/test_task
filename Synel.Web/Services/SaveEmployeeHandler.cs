using System.Threading.Tasks;
using Synel.Web.Data;
using Synel.Web.Models;

namespace Synel.Web.Services
{
    public class SaveEmployeeHandler : IRequestHandler<SaveEmployee, bool>
    {
        private readonly EmployeeContext _db;

        public SaveEmployeeHandler(EmployeeContext db)
        {
            _db = db;
        }

        public async Task<bool> Handle(SaveEmployee request)
        {
            _db.Update(request.Value);
            return await _db.SaveChangesAsync() > 0;
        }
    }
}