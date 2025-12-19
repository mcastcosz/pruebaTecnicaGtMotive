using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.GetAvailable
{
    /// <summary>
    /// Represents an available vehicle item.
    /// </summary>
    public sealed class AvailableVehicleItem(string code, DateTime manufacturedAt)
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
