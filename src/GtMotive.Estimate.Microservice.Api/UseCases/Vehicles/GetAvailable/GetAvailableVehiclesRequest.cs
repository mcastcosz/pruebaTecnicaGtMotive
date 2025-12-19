using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.GetAvailable
{
    public sealed class GetAvailableVehiclesRequest : IRequest<IWebApiPresenter>
    {
    }
}
