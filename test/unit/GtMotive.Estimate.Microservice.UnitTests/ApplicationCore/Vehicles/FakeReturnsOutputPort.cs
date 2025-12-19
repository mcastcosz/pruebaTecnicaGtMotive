using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Returns;

namespace GtMotive.Estimate.Microservice.UnitTests.ApplicationCore.Vehicles
{
    /// <summary>
    /// Captures which output path was executed by the use case.
    /// </summary>
    internal enum OutputCall
    {
        /// <summary>
        /// No calls have been executed.
        /// </summary>
        None,

        /// <summary>
        /// Standard output was executed.
        /// </summary>
        Standard,

        /// <summary>
        /// NotFound output was executed.
        /// </summary>
        NotFound,

        /// <summary>
        /// VehicleNotRented output was executed.
        /// </summary>
        VehicleNotRented,
    }

    internal sealed class FakeReturnsOutputPort : IReturnsVehicleOutputPort
    {
        public OutputCall LastCall { get; private set; } = OutputCall.None;

        public void StandardHandle(ReturnsVehicleOutput response) => LastCall = OutputCall.Standard;

        public void NotFoundHandle(string message) => LastCall = OutputCall.NotFound;

        public void VehicleNotRentedHandle(string message) => LastCall = OutputCall.VehicleNotRented;
    }
}
