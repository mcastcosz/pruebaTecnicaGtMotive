namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Rent
{
    /// <summary>
    /// Output data returned after renting a vehicle.
    /// </summary>
    public sealed class RentVehicleOutput(string code, string renterId) : IUseCaseOutput
    {
        /// <summary>
        /// Gets vehicle code.
        /// </summary>
        public string Code { get; } = code;

        /// <summary>
        /// Gets renter identifier.
        /// </summary>
        public string RenterId { get; } = renterId;
    }
}
