using System;

namespace Synel.Web.Models
{
    public class GetEmployeeById : IRequest<Employee>
    {
        public Guid Id { get; set; }
    }
}