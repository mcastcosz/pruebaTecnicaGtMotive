using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Create
{
    /// <summary>
    /// Output data returned after creating a vehicle.
    /// </summary>
    public sealed class CreateVehicleOutput(string code, DateTime manufacturedAt) : IUseCaseOutput
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
