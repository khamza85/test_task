using System.Threading.Tasks;
using Synel.Web.Models;

namespace Synel.Web.Services
{
    public interface IMediator
    {
        Task<TResult> Process<TResult>(IRequest<TResult> request);
    }
}