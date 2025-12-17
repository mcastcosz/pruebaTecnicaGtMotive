using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.Create;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Create
{
    public sealed class CreateVehicleRequestHandler(ICreateVehicleUseCase useCase, CreateVehiclePresenter presenter)
        : IRequestHandler<CreateVehicleRequest, IWebApiPresenter>
    {
        private readonly ICreateVehicleUseCase _useCase = useCase;
        private readonly CreateVehiclePresenter _presenter = presenter;

        public async Task<IWebApiPresenter> Handle(CreateVehicleRequest request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            var input = new CreateVehicleInput(
                request.Code,
                request.ManufacturedAt!.Value);

            await _useCase.Execute(input).ConfigureAwait(false);

            return _presenter;
        }
    }
}
