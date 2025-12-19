using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Create;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.GetAvailable;
using GtMotive.Estimate.Microservice.FunctionalTests.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace GtMotive.Estimate.Microservice.FunctionalTests.Specs.Vehicles
{
    public sealed class CreateAndGetAvailableVehiclesFunctionalTests
    {
        [Fact]
        public async Task CreateThenGetAvailableReturnsAtLeastOneVehicle()
        {
            var manufacturedAt = new DateTime(2023, 6, 1, 0, 0, 0, DateTimeKind.Utc);

            await FunctionalCompositionRoot.UsingHandlerForRequestResponse<CreateVehicleRequest, IWebApiPresenter>(async handler =>
            {
                var request = new CreateVehicleRequest
                {
                    Code = "VH-FUNC-001",
                    ManufacturedAt = manufacturedAt,
                };

                var presenter = await handler.Handle(request, CancellationToken.None);

                var created = Assert.IsType<ObjectResult>(presenter.ActionResult, exactMatch: false);
                Assert.Equal(201, created.StatusCode);

                var response = Assert.IsType<CreateVehicleResponse>(created.Value);
                Assert.Equal("VH-FUNC-001", response.Code);

                Assert.Equal("VH-FUNC-001", response.Code);
            });

            await FunctionalCompositionRoot.UsingHandlerForRequestResponse<GetAvailableVehiclesRequest, IWebApiPresenter>(async handler =>
            {
                var presenter = await handler.Handle(new GetAvailableVehiclesRequest(), CancellationToken.None);

                var ok = Assert.IsType<OkObjectResult>(presenter.ActionResult);

                var vehicles = Assert.IsType<GetAvailableVehiclesResponse>(ok.Value, exactMatch: false);
                Assert.NotEmpty(vehicles.Vehicles);
            });
        }
    }
}
