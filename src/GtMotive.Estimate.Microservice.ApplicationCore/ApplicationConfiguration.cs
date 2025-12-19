using System;
using System.Diagnostics.CodeAnalysis;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Create;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.GetAvailable;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Rent;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Returns;
using Microsoft.Extensions.DependencyInjection;

[assembly: CLSCompliant(false)]

namespace GtMotive.Estimate.Microservice.ApplicationCore
{
    /// <summary>
    /// Adds Use Cases classes.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class ApplicationConfiguration
    {
        /// <summary>
        /// Adds Use Cases to the ServiceCollection.
        /// </summary>
        /// <param name="services">Service Collection.</param>
        /// <returns>The modified instance.</returns>
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            ArgumentNullException.ThrowIfNull(services);

            services.AddScoped<ICreateVehicleUseCase, CreateVehicleUseCase>();
            services.AddScoped<IGetAvailableVehiclesUseCase, GetAvailableVehiclesUseCase>();
            services.AddScoped<IRentVehicleUseCase, RentVehicleUseCase>();
            services.AddScoped<IReturnsVehicleUseCase, ReturnsVehicleUseCase>();

            return services;
        }
    }
}
