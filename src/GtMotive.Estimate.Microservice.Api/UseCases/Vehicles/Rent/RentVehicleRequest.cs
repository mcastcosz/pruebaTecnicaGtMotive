using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Rent
{
    public sealed class RentVehicleRequest(string code, string renterId) : IRequest<IWebApiPresenter>
    {
        public string Code { get; } = code;

        public string RenterId { get; } = renterId;
    }
}
