namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Rent
{
    /// <summary>
    /// Output port for the rent vehicle use case.
    /// </summary>
    public interface IRentVehicleOutputPort : IOutputPortStandard<RentVehicleOutput>, IOutputPortNotFound
    {
        /// <summary>
        /// Called when the vehicle is already rented.
        /// </summary>
        /// <param name="message">Error message.</param>
        void VehicleAlreadyRentedHandle(string message);

        /// <summary>
        /// Called when the renter already has an active rental.
        /// </summary>
        /// <param name="message">Error message.</param>
        void RenterAlreadyHasActiveRentalHandle(string message);
    }
}
