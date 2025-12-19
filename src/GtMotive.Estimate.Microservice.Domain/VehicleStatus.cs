namespace GtMotive.Estimate.Microservice.Domain
{
    /// <summary>
    /// Represents the vehicle availability status.
    /// </summary>
    public enum VehicleStatus
    {
        /// <summary>
        /// The vehicle is available for rent.
        /// </summary>
        Available = 0,

        /// <summary>
        /// The vehicle is currently rented.
        /// </summary>
        Rented = 1,
    }
}
