using System;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.InfrastructureTests.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace GtMotive.Estimate.Microservice.InfrastructureTests.Specs.Vehicles
{
    public sealed class VehiclesModelValidationInfrastructureTests : IDisposable
    {
        private readonly GenericInfrastructureTestServerFixture _fixture = new();

        public void Dispose()
        {
            _fixture.Dispose();
        }

        [Fact]
        public async Task PostVehiclesWhenManufacturedAtMissingReturnsBadRequest()
        {
            using var client = _fixture.Server.CreateClient();

            var body = new
            {
                code = "VH-INF-VAL-001",
            };

            var response = await client.PostAsJsonAsync("/vehicles", body);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            var problem = await response.Content.ReadFromJsonAsync<ValidationProblemDetails>();

            Assert.NotNull(problem);
            Assert.True(problem!.Errors.ContainsKey("ManufacturedAt"));
        }
    }
}
