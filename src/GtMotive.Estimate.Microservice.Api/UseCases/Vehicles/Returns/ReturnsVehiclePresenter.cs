using System;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Returns;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Returns
{
    public sealed class ReturnsVehiclePresenter : IWebApiPresenter, IReturnsVehicleOutputPort
    {
        public IActionResult ActionResult { get; private set; } = new StatusCodeResult(500);

        public void StandardHandle(ReturnsVehicleOutput response)
        {
            ArgumentNullException.ThrowIfNull(response);

            var viewModel = new ReturnsVehicleResponse(response.Code);
            ActionResult = new OkObjectResult(viewModel);
        }

        public void NotFoundHandle(string message)
        {
            ActionResult = new NotFoundObjectResult(new ProblemDetails
            {
                Title = "Not Found",
                Status = 404,
                Detail = message,
            });
        }

        public void VehicleNotRentedHandle(string message)
        {
            ActionResult = new BadRequestObjectResult(new ProblemDetails
            {
                Title = "Bad Request",
                Status = 400,
                Detail = message,
            });
        }
    }
}
