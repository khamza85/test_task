using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Synel.Web.Models;
using Synel.Web.Services;

namespace Synel.Web.Utils
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRequestHandlers(this IServiceCollection service)
        {
            service.TryAddTransient<IMediator, Mediator>();
            service.TryAddTransient<IRequestHandler<QueryEmployees, Employee[]>, QueryEmployeesHandler>();
            service.TryAddTransient<IRequestHandler<GetEmployeeById, Employee>, GetEmployeeByIdHandler>();
            service.TryAddTransient<IRequestHandler<RemoveEmployee, bool>, RemoveEmployeeHandler>();
            service.TryAddTransient<IRequestHandler<SaveEmployee, bool>, SaveEmployeeHandler>();
            service.TryAddTransient<IRequestHandler<ImportCsv, int>, ImportCsvHandler>();
            return service;
        }
    }
}