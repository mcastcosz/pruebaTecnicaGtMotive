using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Create
{
    /// <summary>
    /// Use case implementation for creating a vehicle.
    /// </summary>
    public sealed class CreateVehicleUseCase(IVehicleRepository vehicleRepository, ICreateVehicleOutputPort outputPort)
    : ICreateVehicleUseCase
    {
        private readonly IVehicleRepository _vehicleRepository = vehicleRepository;

        private readonly ICreateVehicleOutputPort _outputPort = outputPort;

        /// <summary>
        /// Executes the create vehicle use case.
        /// </summary>
        /// <param name="input">Input data.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task Execute(CreateVehicleInput input)
        {
            ArgumentNullException.ThrowIfNull(input);

            // no permitir vehículos con fabricación > 5 años.
            var maxAge = DateTime.UtcNow.AddYears(-5);
            if (input.ManufacturedAt < maxAge)
            {
                throw new DomainException("No se admiten vehículos con fecha de fabricación superior a 5 años.");
            }

            var vehicle = new Vehicle(input.Code, input.ManufacturedAt, VehicleStatus.Available);
            await _vehicleRepository.Add(vehicle).ConfigureAwait(false);

            var output = new CreateVehicleOutput(input.Code, input.ManufacturedAt);
            _outputPort.StandardHandle(output);
        }
    }
}
