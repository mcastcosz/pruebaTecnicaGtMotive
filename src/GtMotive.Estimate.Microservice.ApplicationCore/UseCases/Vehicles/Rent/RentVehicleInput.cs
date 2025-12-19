namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Rent
{
    /// <summary>
    /// Input data required to rent a vehicle.
    /// </summary>
    public sealed class RentVehicleInput(string code, string renterId) : IUseCaseInput
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
