using System.ComponentModel.DataAnnotations;

namespace Synel.Web.Models
{
    public class QueryEmployees : IRequest<Employee[]>
    {
        public string Search { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Sort { get; set; } = nameof(Employee.LastName);
    }
}