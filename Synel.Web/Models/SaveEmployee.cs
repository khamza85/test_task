namespace Synel.Web.Models
{
    public class SaveEmployee : IRequest<bool>
    {
        public Employee Value { get; set; }
    }
}