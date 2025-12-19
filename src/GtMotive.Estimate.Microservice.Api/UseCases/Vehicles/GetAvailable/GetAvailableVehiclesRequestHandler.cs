using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.GetAvailable;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.GetAvailable
{
    public sealed class GetAvailableVehiclesRequestHandler(
        IGetAvailableVehiclesUseCase useCase,
        GetAvailableVehiclesPresenter presenter)
        : IRequestHandler<GetAvailableVehiclesRequest, IWebApiPresenter>
    {
        private readonly IGetAvailableVehiclesUseCase _useCase = useCase;
        private readonly GetAvailableVehiclesPresenter _presenter = presenter;

        public async Task<IWebApiPresenter> Handle(GetAvailableVehiclesRequest request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            await _useCase.Execute(new GetAvailableVehiclesInput()).ConfigureAwait(false);

            return _presenter;
        }
    }
}
