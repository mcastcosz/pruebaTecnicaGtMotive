using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.UnitTests.ApplicationCore.Vehicles
{
    internal sealed class FakeVehicleRepository(Vehicle vehicle) : IVehicleRepository
    {
        private readonly Vehicle _vehicle = vehicle;

        public bool UpdateCalled { get; private set; }

        public Task Add(Vehicle vehicle) => Task.CompletedTask;

        public Task Update(Vehicle vehicle)
        {
            UpdateCalled = true;
            return Task.CompletedTask;
        }

        public Task<IReadOnlyCollection<Vehicle>> GetAvailable() =>
            Task.FromResult<IReadOnlyCollection<Vehicle>>([]);

        public Task<Vehicle> GetByCode(string code) =>
            Task.FromResult(string.Equals(code, _vehicle.Code, StringComparison.OrdinalIgnoreCase) ? _vehicle : null);

        public Task<bool> HasActiveRental(string renterId) => Task.FromResult(false);
    }
}
