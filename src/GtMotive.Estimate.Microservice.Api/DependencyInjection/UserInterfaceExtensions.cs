using System;
using System.Diagnostics.CodeAnalysis;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Create;
using Microsoft.Extensions.DependencyInjection;

namespace GtMotive.Estimate.Microservice.Api.DependencyInjection
{
    [ExcludeFromCodeCoverage]
    public static class UserInterfaceExtensions
    {
        public static IServiceCollection AddPresenters(this IServiceCollection services)
        {
            ArgumentNullException.ThrowIfNull(services);

            services.AddScoped<CreateVehiclePresenter>();
            services.AddScoped<ApplicationCore.UseCases.Vehicles.Create.ICreateVehicleOutputPort>(sp => sp.GetRequiredService<CreateVehiclePresenter>());

            return services;
        }
    }
}
