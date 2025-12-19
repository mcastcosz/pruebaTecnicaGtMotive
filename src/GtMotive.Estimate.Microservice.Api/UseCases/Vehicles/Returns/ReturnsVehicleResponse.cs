using System.ComponentModel.DataAnnotations;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Returns
{
    public sealed class ReturnsVehicleResponse(string code)
    {
        [Required]
        public string Code { get; } = code;
    }
}
