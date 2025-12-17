using System;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Create;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Create
{
    public sealed class CreateVehiclePresenter() : IWebApiPresenter, ICreateVehicleOutputPort
    {
        public IActionResult ActionResult { get; private set; } = new StatusCodeResult(500);

        public void StandardHandle(CreateVehicleOutput response)
        {
            ArgumentNullException.ThrowIfNull(response);

            var viewModel = new CreateVehicleResponse(response.Code, response.ManufacturedAt);
            ActionResult = new CreatedResult($"/vehicles/{viewModel.Code}", viewModel);
        }
    }
}
