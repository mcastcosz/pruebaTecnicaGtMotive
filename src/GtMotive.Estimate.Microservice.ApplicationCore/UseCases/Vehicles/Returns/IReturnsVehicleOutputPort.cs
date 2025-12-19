namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Returns
{
    /// <summary>
    /// Output port for the return vehicle use case.
    /// </summary>
    public interface IReturnsVehicleOutputPort : IOutputPortStandard<ReturnsVehicleOutput>, IOutputPortNotFound
    {
        /// <summary>
        /// Called when the vehicle is not rented.
        /// </summary>
        /// <param name="message">Error message.</param>
        void VehicleNotRentedHandle(string message);
    }
}
