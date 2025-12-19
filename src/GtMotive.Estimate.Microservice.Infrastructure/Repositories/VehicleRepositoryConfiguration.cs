using System;
using System.Diagnostics.CodeAnalysis;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GtMotive.Estimate.Microservice.Infrastructure.Repositories
{
    [ExcludeFromCodeCoverage]
    public static class VehicleRepositoryConfiguration
    {
        public static IServiceCollection AddVehicleRepository(this IServiceCollection services)
        {
            ArgumentNullException.ThrowIfNull(services);

            services.AddSingleton<IVehicleRepository, InMemoryVehicleRepository>();

            return services;
        }
    }
}
