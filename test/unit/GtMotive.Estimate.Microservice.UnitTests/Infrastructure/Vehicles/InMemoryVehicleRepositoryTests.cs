using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain;
using GtMotive.Estimate.Microservice.Infrastructure.Repositories;
using Xunit;

namespace GtMotive.Estimate.Microservice.UnitTests.Infrastructure.Repositories
{
    public sealed class InMemoryVehicleRepositoryTests
    {
        [Fact]
        public async Task HasActiveRentalWhenRentedVehicleExistsReturnsTrue()
        {
            var manufacturedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            var repo = new InMemoryVehicleRepository();

            var vehicle = new Vehicle("VH-INF-UT-1", manufacturedAt, VehicleStatus.Available);
            vehicle.RentTo("P-001");

            await repo.Add(vehicle);

            var result = await repo.HasActiveRental("P-001");

            Assert.True(result);
        }

        [Fact]
        public async Task HasActiveRentalWhenNoRentedVehicleExistsReturnsFalse()
        {
            var manufacturedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            var repo = new InMemoryVehicleRepository();

            var vehicle = new Vehicle("VH-INF-UT-2", manufacturedAt, VehicleStatus.Available);

            await repo.Add(vehicle);

            var result = await repo.HasActiveRental("P-002");

            Assert.False(result);
        }
    }
}
