using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Infrastructure;
using GtMotive.Estimate.Microservice.Infrastructure.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GtMotive.Estimate.Microservice.FunctionalTests.Infrastructure
{
    internal static class FunctionalCompositionRoot
    {
        public static async Task UsingHandlerForRequestResponse<TRequest, TResponse>(
            Func<IRequestHandler<TRequest, TResponse>, Task> handlerAction)
            where TRequest : IRequest<TResponse>
        {
            ArgumentNullException.ThrowIfNull(handlerAction);

            using var provider = BuildServiceProvider();
            using var scope = provider.CreateScope();

            var handler = scope.ServiceProvider.GetRequiredService<IRequestHandler<TRequest, TResponse>>();
            await handlerAction(handler);
        }

        private static ServiceProvider BuildServiceProvider()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            var services = new ServiceCollection();

            services.AddSingleton<IConfiguration>(configuration);

            services.AddApiDependencies();
            services.AddLogging();

            services.AddBaseInfrastructure(isDevelopment: true);

            services.AddSingleton<IVehicleRepository, InMemoryVehicleRepository>();

            return services.BuildServiceProvider();
        }
    }
}
