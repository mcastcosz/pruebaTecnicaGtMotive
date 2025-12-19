using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Returns
{
    public sealed class ReturnsVehicleRequest(string code) : IRequest<IWebApiPresenter>
    {
        public string Code { get; } = code;
    }
}
