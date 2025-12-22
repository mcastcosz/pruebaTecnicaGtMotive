namespace GtMotive.Estimate.Microservice.Api.Dto
{
    public record ServiceStatusDto
    {
        public string Service { get; init; }

        public string Environment { get; init; }

        public string Status { get; init; }

        public ServiceEndpointsDto Endpoints { get; init; }
    }

    public record ServiceEndpointsDto
    {
        public string Health { get; init; }

        public string Swagger { get; init; }
    }
}
