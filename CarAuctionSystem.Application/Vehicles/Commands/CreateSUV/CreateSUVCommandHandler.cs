using AutoMapper;
using CarAuctionSystem.Domain.Entities.Vehicles;
using CarAuctionSystem.Application.Common.Interfaces.Repositories;
using CarAuctionSystem.Application.Common.Errors;
using ErrorOr;
using MediatR;

namespace CarAuctionSystem.Application.Vehicles.Commands.CreateSUV;

public class CreateSUVCommandHandler : IRequestHandler<CreateSUVCommand, ErrorOr<Guid>>
{
    private readonly IVehicleRepository _repository;
    private readonly IMapper _mapper;

    public CreateSUVCommandHandler(
       IVehicleRepository repository,
       IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException();
        _mapper = mapper ?? throw new ArgumentNullException();
    }

    public async Task<ErrorOr<Guid>> Handle(CreateSUVCommand request, CancellationToken cancellationToken)
    {
        if (await _repository.ExistsVINAsync(request.VIN))
        {
            return Errors.Vehicles.DuplicateId;
        }
        var record = _mapper.Map<SUV>(request);
        record.Id = SUV.CreateNewId();

        var result = await _repository.InsertRecordAsync<SUV>(record);
        return result.Id;
    }
}