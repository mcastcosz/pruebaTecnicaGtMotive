using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Create
{
    public sealed class CreateVehicleRequest : IRequest<IWebApiPresenter>
    {
        [Required]
        [MinLength(3)]
        public string Code { get; init; } = default!;

        [Required]
        public DateTime? ManufacturedAt { get; init; }
    }
}
