using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.InfrastructureTests.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace GtMotive.Estimate.Microservice.InfrastructureTests.Specs.Vehicles
{
    internal sealed class VehiclesModelValidationInfrastructureTests(GenericInfrastructureTestServerFixture fixture)
        : InfrastructureTestBase(fixture)
    {
        [Fact]
        public async Task PostVehiclesWhenManufacturedAtMissingReturnsBadRequest()
        {
            using var client = Fixture.Server.CreateClient();

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
