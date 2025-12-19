using System.ComponentModel.DataAnnotations;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Rent
{
    public sealed class RentVehicleBody(string renterId)
    {
        [Required]
        public string RenterId { get; } = renterId;
    }
}
