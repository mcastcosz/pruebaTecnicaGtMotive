using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.Infrastructure.Repositories
{
    /// <summary>
    /// In-memory vehicle repository for local execution and testing.
    /// </summary>
    public sealed class InMemoryVehicleRepository : IVehicleRepository
    {
        private static readonly ConcurrentDictionary<string, Vehicle> Vehicles = new(StringComparer.OrdinalIgnoreCase);

        /// <inheritdoc />
        public Task Add(Vehicle vehicle)
        {
            ArgumentNullException.ThrowIfNull(vehicle);
            return Update(vehicle);
        }

        /// <inheritdoc />
        public Task Update(Vehicle vehicle)
        {
            ArgumentNullException.ThrowIfNull(vehicle);
            return Upsert(vehicle);
        }

        /// <inheritdoc />
        public Task<IReadOnlyCollection<Vehicle>> GetAvailable()
        {
            var result = Vehicles.Values.Where(v => v.Status == VehicleStatus.Available).ToArray();
            return Task.FromResult<IReadOnlyCollection<Vehicle>>(result);
        }

        /// <inheritdoc />
        public Task<Vehicle> GetByCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                return Task.FromResult<Vehicle>(null);
            }

            Vehicles.TryGetValue(code, out var vehicle);
            return Task.FromResult(vehicle);
        }

        /// <inheritdoc />
        public Task<bool> HasActiveRental(string renterId)
        {
            if (string.IsNullOrWhiteSpace(renterId))
            {
                return Task.FromResult(false);
            }

            var exists = Vehicles.Values.Any(v => v.Status == VehicleStatus.Rented && v.RenterId == renterId);
            return Task.FromResult(exists);
        }

        private static Task Upsert(Vehicle vehicle)
        {
            Vehicles[vehicle.Code] = vehicle;
            return Task.CompletedTask;
        }
    }
}
