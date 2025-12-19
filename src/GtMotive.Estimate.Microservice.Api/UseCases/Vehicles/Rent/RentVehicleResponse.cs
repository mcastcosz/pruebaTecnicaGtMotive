using System.ComponentModel.DataAnnotations;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Rent
{
    public sealed class RentVehicleResponse(string code, string renterId)
    {
        [Required]
        public string Code { get; } = code;

        [Required]
        public string RenterId { get; } = renterId;
    }
}
