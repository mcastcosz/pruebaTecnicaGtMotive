using System;
using System.Linq;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.GetAvailable
{
    /// <summary>
    /// Use case implementation for getting available vehicles.
    /// </summary>
    public sealed class GetAvailableVehiclesUseCase(
        IVehicleRepository vehicleRepository,
        IGetAvailableVehiclesOutputPort outputPort)
        : IGetAvailableVehiclesUseCase
    {
        private readonly IVehicleRepository _vehicleRepository = vehicleRepository;
        private readonly IGetAvailableVehiclesOutputPort _outputPort = outputPort;

        /// <summary>
        /// Executes the get available vehicles use case.
        /// </summary>
        /// <param name="input">Input data.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task Execute(GetAvailableVehiclesInput input)
        {
            ArgumentNullException.ThrowIfNull(input);

            var vehicles = await _vehicleRepository.GetAvailable().ConfigureAwait(false);

            var items = vehicles
                .Select(v => new AvailableVehicleItem(v.Code, v.ManufacturedAt))
                .ToArray();

            var output = new GetAvailableVehiclesOutput(items);
            _outputPort.StandardHandle(output);
        }
    }
}
