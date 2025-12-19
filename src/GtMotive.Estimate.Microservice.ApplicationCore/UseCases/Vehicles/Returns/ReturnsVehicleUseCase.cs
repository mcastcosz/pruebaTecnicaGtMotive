using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Returns
{
    /// <summary>
    /// Use case implementation for returning a vehicle.
    /// </summary>
    public sealed class ReturnsVehicleUseCase(
        IVehicleRepository vehicleRepository,
        IReturnsVehicleOutputPort outputPort)
        : IReturnsVehicleUseCase
    {
        private readonly IVehicleRepository _vehicleRepository = vehicleRepository;
        private readonly IReturnsVehicleOutputPort _outputPort = outputPort;

        /// <summary>
        /// Executes the return vehicle use case.
        /// </summary>
        /// <param name="input">Input data.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task Execute(ReturnsVehicleInput input)
        {
            ArgumentNullException.ThrowIfNull(input);

            var vehicle = await _vehicleRepository.GetByCode(input.Code).ConfigureAwait(false);
            if (vehicle is null)
            {
                _outputPort.NotFoundHandle($"El vehículo '{input.Code}' no existe.");
                return;
            }

            try
            {
                vehicle.Return();
            }
            catch (DomainException ex)
            {
                _outputPort.VehicleNotRentedHandle(ex.Message);
                return;
            }

            await _vehicleRepository.Update(vehicle).ConfigureAwait(false);

            var output = new ReturnsVehicleOutput(vehicle.Code);
            _outputPort.StandardHandle(output);
        }
    }
}
