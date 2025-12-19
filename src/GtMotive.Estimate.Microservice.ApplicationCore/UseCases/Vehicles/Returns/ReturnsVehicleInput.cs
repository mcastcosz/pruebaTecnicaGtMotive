namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Returns
{
    /// <summary>
    /// Input data required to return a vehicle.
    /// </summary>
    public sealed class ReturnsVehicleInput(string code) : IUseCaseInput
    {
        /// <summary>
        /// Gets vehicle code.
        /// </summary>
        public string Code { get; } = code;
    }
}
