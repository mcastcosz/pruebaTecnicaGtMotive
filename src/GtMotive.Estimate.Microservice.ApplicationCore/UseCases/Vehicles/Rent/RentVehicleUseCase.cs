using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Rent
{
    /// <summary>
    /// Use case implementation for renting a vehicle.
    /// </summary>
    public sealed class RentVehicleUseCase(
        IVehicleRepository vehicleRepository,
        IRentVehicleOutputPort outputPort)
        : IRentVehicleUseCase
    {
        private readonly IVehicleRepository _vehicleRepository = vehicleRepository;
        private readonly IRentVehicleOutputPort _outputPort = outputPort;

        /// <summary>
        /// Executes the rent vehicle use case.
        /// </summary>
        /// <param name="input">Input data.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task Execute(RentVehicleInput input)
        {
            ArgumentNullException.ThrowIfNull(input);

            if (await _vehicleRepository.HasActiveRental(input.RenterId).ConfigureAwait(false))
            {
                _outputPort.RenterAlreadyHasActiveRentalHandle("Una misma persona no puede alquilar más de 1 vehículo al mismo tiempo.");
                return;
            }

            var vehicle = await _vehicleRepository.GetByCode(input.Code).ConfigureAwait(false);
            if (vehicle is null)
            {
                _outputPort.NotFoundHandle($"El vehículo '{input.Code}' no existe.");
                return;
            }

            try
            {
                vehicle.RentTo(input.RenterId);
            }
            catch (DomainException ex)
            {
                _outputPort.VehicleAlreadyRentedHandle(ex.Message);
                return;
            }

            await _vehicleRepository.Update(vehicle).ConfigureAwait(false);

            var output = new RentVehicleOutput(vehicle.Code, input.RenterId);
            _outputPort.StandardHandle(output);
        }
    }
}
