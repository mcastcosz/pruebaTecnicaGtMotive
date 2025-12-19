using System;

namespace GtMotive.Estimate.Microservice.Domain
{
    /// <summary>
    /// Represents a vehicle in the fleet.
    /// </summary>
    public sealed class Vehicle(string code, DateTime manufacturedAt, VehicleStatus status)
    {
        /// <summary>
        /// Gets the vehicle code.
        /// </summary>
        public string Code { get; } = code;

        /// <summary>
        /// Gets the manufactured date.
        /// </summary>
        public DateTime ManufacturedAt { get; } = manufacturedAt;

        /// <summary>
        /// Gets the vehicle status.
        /// </summary>
        public VehicleStatus Status { get; private set; } = status;

        /// <summary>
        /// Gets the current renter identifier when the vehicle is rented.
        /// </summary>
        public string RenterId { get; private set; }

        /// <summary>
        /// Rents the vehicle to the specified renter.
        /// </summary>
        /// <param name="renterId">Renter identifier.</param>
        public void RentTo(string renterId)
        {
            if (string.IsNullOrWhiteSpace(renterId))
            {
                throw new DomainException("El identificador de la persona es obligatorio.");
            }

            if (Status == VehicleStatus.Rented)
            {
                throw new DomainException("El vehículo ya está alquilado.");
            }

            Status = VehicleStatus.Rented;
            RenterId = renterId;
        }

        /// <summary>
        /// Returns the vehicle to available status.
        /// </summary>
        public void Return()
        {
            if (Status == VehicleStatus.Available)
            {
                throw new DomainException("El vehículo no está alquilado.");
            }

            Status = VehicleStatus.Available;
            RenterId = string.Empty;
        }
    }
}
