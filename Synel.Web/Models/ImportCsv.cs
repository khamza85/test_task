using Microsoft.AspNetCore.Http;

namespace Synel.Web.Models
{
    public class ImportCsv : IRequest<int>
    {
        public IFormFile Csv { get; set; }
    }
}