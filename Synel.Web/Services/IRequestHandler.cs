using System.Threading.Tasks;
using Synel.Web.Models;

namespace Synel.Web.Services
{
    public interface IRequestHandler<in TRequest, TResult> where TRequest : IRequest<TResult>
    {
        Task<TResult> Handle(TRequest request);
    }
}