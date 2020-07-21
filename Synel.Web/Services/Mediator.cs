using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Synel.Web.Models;

namespace Synel.Web.Services
{
    public class Mediator : IMediator
    {
        private readonly IServiceProvider _sp;

        public Mediator(IServiceProvider sp)
        {
            _sp = sp;
        }

        public Task<TResult> Process<TResult>(IRequest<TResult> request)
        {
            var method = GetType()
                .GetMethod(nameof(Handle), BindingFlags.Instance | BindingFlags.NonPublic)!
                .MakeGenericMethod(request.GetType(), typeof(TResult));

            return (Task<TResult>) method.Invoke(this, new object[] {request});
        }

        private Task<TResult> Handle<TRequest, TResult>(TRequest request) where TRequest : IRequest<TResult> =>
            _sp.GetService<IRequestHandler<TRequest, TResult>>().Handle(request);
    }
}