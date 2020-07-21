using System;

namespace Synel.Web.Models
{
    public class RemoveEmployee : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}