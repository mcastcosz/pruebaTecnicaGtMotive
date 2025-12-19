using System.Collections.Generic;
using System.Threading.Tasks;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces
{
    /// <summary>
    /// Defines persistence operations for vehicles.
    /// </summary>
    public interface IVehicleRepository
    {
        /// <summary>
        /// Adds a new vehicle.
        /// </summary>
        /// <param name="vehicle">Vehicle to add.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task Add(Vehicle vehicle);

        /// <summary>
        /// Gets all available vehicles.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task<IReadOnlyCollection<Vehicle>> GetAvailable();

        /// <summary>
        /// Gets a vehicle by code.
        /// </summary>
        /// <param name="code">Vehicle code.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task<Vehicle> GetByCode(string code);

        /// <summary>
        /// Checks if the renter already has an active rented vehicle.
        /// </summary>
        /// <param name="renterId">Renter identifier.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task<bool> HasActiveRental(string renterId);

        /// <summary>
        /// Updates a vehicle.
        /// </summary>
        /// <param name="vehicle">Vehicle to update.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task Update(Vehicle vehicle);
    }
}
