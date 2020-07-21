using Microsoft.EntityFrameworkCore;
using Synel.Web.Models;

namespace Synel.Web.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
    }
}