using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Returns;
using GtMotive.Estimate.Microservice.Domain;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using Xunit;

namespace GtMotive.Estimate.Microservice.UnitTests.ApplicationCore.Vehicles
{
    public sealed class ReturnsVehicleUseCaseTests
    {
        [Fact]
        public async Task ExecuteWhenVehicleExistsAndIsRentedUpdatesAndReturnsStandard()
        {
            // Arrange
            var manufacturedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            var vehicle = new Vehicle("VH-UT-APP-1", manufacturedAt, VehicleStatus.Available);
            vehicle.RentTo("P-001");

            IVehicleRepository repo = new FakeVehicleRepository(vehicle);
            var output = new FakeReturnsOutputPort();

            var useCase = new ReturnsVehicleUseCase(repo, output);

            // Act
            await useCase.Execute(new ReturnsVehicleInput("VH-UT-APP-1"));

            // Assert
            Assert.True(((FakeVehicleRepository)repo).UpdateCalled);
            Assert.Equal(OutputCall.Standard, output.LastCall);
        }
    }
}
