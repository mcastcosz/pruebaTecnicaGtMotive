using System;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Rent;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Rent
{
    public sealed class RentVehiclePresenter : IWebApiPresenter, IRentVehicleOutputPort
    {
        public IActionResult ActionResult { get; private set; } = new StatusCodeResult(500);

        public void StandardHandle(RentVehicleOutput response)
        {
            ArgumentNullException.ThrowIfNull(response);

            var viewModel = new RentVehicleResponse(response.Code, response.RenterId);
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

        public void VehicleAlreadyRentedHandle(string message)
        {
            ActionResult = new BadRequestObjectResult(new ProblemDetails
            {
                Title = "Bad Request",
                Status = 400,
                Detail = message,
            });
        }

        public void RenterAlreadyHasActiveRentalHandle(string message)
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
