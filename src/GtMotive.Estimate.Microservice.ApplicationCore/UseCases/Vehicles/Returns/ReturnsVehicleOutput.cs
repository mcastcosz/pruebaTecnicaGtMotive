namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Returns
{
    /// <summary>
    /// Output data returned after returning a vehicle.
    /// </summary>
    public sealed class ReturnsVehicleOutput(string code) : IUseCaseOutput
    {
        /// <summary>
        /// Gets vehicle code.
        /// </summary>
        public string Code { get; } = code;
    }
}
