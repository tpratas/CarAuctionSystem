using AutoMapper;
using CarAuctionSystem.Domain.Entities.Vehicles;
using CarAuctionSystem.Application.Common.Interfaces.Repositories;
using CarAuctionSystem.Application.Common.Errors;
using ErrorOr;
using MediatR;

namespace CarAuctionSystem.Application.Vehicles.Commands.CreateHatchback;

public class CreateHatchbackCommandHandler : IRequestHandler<CreateHatchbackCommand, ErrorOr<Guid>>
{
    private readonly IVehicleRepository _repository;
    private readonly IMapper _mapper;

    public CreateHatchbackCommandHandler(
        IVehicleRepository repository,
        IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException();
        _mapper = mapper ?? throw new ArgumentNullException();
    }

    public async Task<ErrorOr<Guid>> Handle(CreateHatchbackCommand request, CancellationToken cancellationToken)
    {
        if (await _repository.ExistsVINAsync(request.VIN))
        {
            return Errors.Vehicles.DuplicateId;
        }

        var record = _mapper.Map<Hatchback>(request);
        record.Id = Hatchback.CreateNewId();

        var result = await _repository.InsertRecordAsync<Hatchback>(record);
        return result.Id;
    }
}




