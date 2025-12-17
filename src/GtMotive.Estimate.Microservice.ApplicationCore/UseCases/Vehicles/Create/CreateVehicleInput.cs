using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Create
{
    /// <summary>
    /// Input data required to create a vehicle.
    /// </summary>
    public sealed class CreateVehicleInput(string code, DateTime manufacturedAt) : IUseCaseInput
    {
        /// <summary>
        /// Gets the vehicle code.
        /// </summary>
        public string Code { get; } = code;

        /// <summary>
        /// Gets the manufactured date.
        /// </summary>
        public DateTime ManufacturedAt { get; } = manufacturedAt;
    }
}
