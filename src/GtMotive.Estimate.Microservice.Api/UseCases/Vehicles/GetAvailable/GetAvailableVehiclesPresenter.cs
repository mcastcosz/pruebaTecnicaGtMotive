using System;
using System.Linq;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.GetAvailable;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.GetAvailable
{
    public sealed class GetAvailableVehiclesPresenter : IWebApiPresenter, IGetAvailableVehiclesOutputPort
    {
        public IActionResult ActionResult { get; private set; } = new StatusCodeResult(500);

        public void StandardHandle(GetAvailableVehiclesOutput response)
        {
            ArgumentNullException.ThrowIfNull(response);

            var items = response.Vehicles
                .Select(v => new GetAvailableVehiclesResponseItem(v.Code, v.ManufacturedAt))
                .ToArray();

            var viewModel = new GetAvailableVehiclesResponse(items);

            ActionResult = new OkObjectResult(viewModel);
        }
    }
}
