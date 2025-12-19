using System.Collections.Generic;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.GetAvailable
{
    /// <summary>
    /// Output data returned after getting available vehicles.
    /// </summary>
    public sealed class GetAvailableVehiclesOutput(IReadOnlyCollection<AvailableVehicleItem> vehicles) : IUseCaseOutput
    {
        /// <summary>
        /// Gets the available vehicles.
        /// </summary>
        public IReadOnlyCollection<AvailableVehicleItem> Vehicles { get; } = vehicles;
    }
}
