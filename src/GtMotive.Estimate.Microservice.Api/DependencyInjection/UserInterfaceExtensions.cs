using System;
using System.Diagnostics.CodeAnalysis;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Create;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.GetAvailable;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Rent;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Returns;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Create;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.GetAvailable;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Rent;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Returns;
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
            services.AddScoped<ICreateVehicleOutputPort>(sp => sp.GetRequiredService<CreateVehiclePresenter>());

            services.AddScoped<GetAvailableVehiclesPresenter>();
            services.AddScoped<IGetAvailableVehiclesOutputPort>(sp => sp.GetRequiredService<GetAvailableVehiclesPresenter>());

            services.AddScoped<RentVehiclePresenter>();
            services.AddScoped<IRentVehicleOutputPort>(sp => sp.GetRequiredService<RentVehiclePresenter>());

            services.AddScoped<ReturnsVehiclePresenter>();
            services.AddScoped<IReturnsVehicleOutputPort>(sp => sp.GetRequiredService<ReturnsVehiclePresenter>());

            return services;
        }
    }
}
