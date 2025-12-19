using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Returns;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Returns
{
    public sealed class ReturnsVehicleRequestHandler(IReturnsVehicleUseCase useCase, ReturnsVehiclePresenter presenter)
        : IRequestHandler<ReturnsVehicleRequest, IWebApiPresenter>
    {
        private readonly IReturnsVehicleUseCase _useCase = useCase;
        private readonly ReturnsVehiclePresenter _presenter = presenter;

        public async Task<IWebApiPresenter> Handle(ReturnsVehicleRequest request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            await _useCase.Execute(new ReturnsVehicleInput(request.Code)).ConfigureAwait(false);

            return _presenter;
        }
    }
}
