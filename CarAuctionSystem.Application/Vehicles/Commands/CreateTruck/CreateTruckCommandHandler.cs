using AutoMapper;
using CarAuctionSystem.Domain.Entities.Vehicles;
using CarAuctionSystem.Application.Common.Interfaces.Repositories;
using CarAuctionSystem.Application.Common.Errors;
using ErrorOr;
using MediatR;

namespace CarAuctionSystem.Application.Vehicles.Commands.CreateTruck;

public class CreateTruckCommandHandler : IRequestHandler<CreateTruckCommand, ErrorOr<Guid>>
{
    private readonly IVehicleRepository _repository;
    private readonly IMapper _mapper;

    public CreateTruckCommandHandler(
     IVehicleRepository repository,
     IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException();
        _mapper = mapper ?? throw new ArgumentNullException();
    }

    public async Task<ErrorOr<Guid>> Handle(CreateTruckCommand request, CancellationToken cancellationToken)
    {
        if (await _repository.ExistsVINAsync(request.VIN))
        {
            return Errors.Vehicles.DuplicateId;
        }

        var record = _mapper.Map<Truck>(request);
        record.Id = Truck.CreateNewId();

        var result = await _repository.InsertRecordAsync<Truck>(record);
        return result.Id;
    }
}