using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Returns;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Returns;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace GtMotive.Estimate.Microservice.UnitTests.Api.Vehicles
{
    public sealed class ReturnsVehiclePresenterTests
    {
        [Fact]
        public void StandardHandleShouldBuildOkObjectResult()
        {
            // Arrange
            var presenter = new ReturnsVehiclePresenter();
            var output = new ReturnsVehicleOutput("VH-UT-API-1");

            // Act
            presenter.StandardHandle(output);

            // Assert
            var ok = Assert.IsType<OkObjectResult>(presenter.ActionResult);
            var model = Assert.IsType<ReturnsVehicleResponse>(ok.Value);
            Assert.Equal("VH-UT-API-1", model.Code);
        }

        [Fact]
        public void NotFoundHandleShouldBuildNotFoundObjectResult()
        {
            // Arrange
            var presenter = new ReturnsVehiclePresenter();

            // Act
            presenter.NotFoundHandle("no existe");

            // Assert
            var notFound = Assert.IsType<NotFoundObjectResult>(presenter.ActionResult);
            var details = Assert.IsType<ProblemDetails>(notFound.Value);
            Assert.Equal(404, details.Status);
        }
    }
}
