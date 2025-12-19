using System;
using System.ComponentModel.DataAnnotations;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.GetAvailable
{
    public sealed class GetAvailableVehiclesResponseItem(string code, DateTime manufacturedAt)
    {
        [Required]
        public string Code { get; } = code;

        [Required]
        public DateTime ManufacturedAt { get; } = manufacturedAt;
    }
}
