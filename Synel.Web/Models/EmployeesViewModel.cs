using System;

namespace Synel.Web.Models
{
    public class EmployeesViewModel
    {
        public QueryEmployees Query { get; set; } = new QueryEmployees();

        public string Alert { get; set; }

        public Employee[] Employees { get; set; } = Array.Empty<Employee>();
    }
}