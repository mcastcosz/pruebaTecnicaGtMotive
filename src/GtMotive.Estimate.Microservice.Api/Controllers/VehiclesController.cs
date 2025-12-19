using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Create;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.GetAvailable;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Rent;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Returns;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    [ApiController]
    [Route("vehicles")]
    public sealed class VehiclesController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateVehicleRequest request)
        {
            var presenter = await _mediator.Send(request);
            return presenter.ActionResult;
        }

        [HttpGet("available")]
        public async Task<IActionResult> GetAvailable()
        {
            var presenter = await _mediator.Send(new GetAvailableVehiclesRequest());
            return presenter.ActionResult;
        }

        [HttpPost("{code}/rent")]
        public async Task<IActionResult> Rent([FromRoute] string code, [FromBody][Required] RentVehicleBody body)
        {
            ArgumentNullException.ThrowIfNull(body);

            var presenter = await _mediator.Send(new RentVehicleRequest(code, body.RenterId));
            return presenter.ActionResult;
        }

        [HttpPost("{code}/returns")]
        public async Task<IActionResult> Returns([FromRoute] string code)
        {
            var presenter = await _mediator.Send(new ReturnsVehicleRequest(code));
            return presenter.ActionResult;
        }
    }
}
