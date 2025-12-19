using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Rent;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Rent
{
    public sealed class RentVehicleRequestHandler(IRentVehicleUseCase useCase, RentVehiclePresenter presenter)
        : IRequestHandler<RentVehicleRequest, IWebApiPresenter>
    {
        private readonly IRentVehicleUseCase _useCase = useCase;
        private readonly RentVehiclePresenter _presenter = presenter;

        public async Task<IWebApiPresenter> Handle(RentVehicleRequest request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            var input = new RentVehicleInput(request.Code, request.RenterId);

            await _useCase.Execute(input).ConfigureAwait(false);

            return _presenter;
        }
    }
}
