using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.GetAvailable
{
    public sealed class GetAvailableVehiclesResponse(IReadOnlyCollection<GetAvailableVehiclesResponseItem> vehicles)
    {
        [Required]
        public IReadOnlyCollection<GetAvailableVehiclesResponseItem> Vehicles { get; } = vehicles;
    }
}
