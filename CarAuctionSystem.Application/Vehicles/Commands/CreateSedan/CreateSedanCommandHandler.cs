using AutoMapper;
using CarAuctionSystem.Domain.Entities.Vehicles;
using CarAuctionSystem.Application.Common.Interfaces.Repositories;
using CarAuctionSystem.Application.Common.Errors;
using ErrorOr;
using MediatR;

namespace CarAuctionSystem.Application.Vehicles.Commands.CreateSedan;

public class CreateSedanCommandHandler : IRequestHandler<CreateSedanCommand, ErrorOr<Guid>>
{
    private readonly IVehicleRepository _repository;
    private readonly IMapper _mapper;

    public CreateSedanCommandHandler(
        IVehicleRepository repository,
        IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException();
        _mapper = mapper ?? throw new ArgumentNullException();
    }

    public async Task<ErrorOr<Guid>> Handle(CreateSedanCommand request, CancellationToken cancellationToken)
    {
        if(await _repository.ExistsVINAsync(request.VIN))
        {
            return Errors.Vehicles.DuplicateId;
        }

        var record = _mapper.Map<Sedan>(request);
        record.Id = Sedan.CreateNewId();

        var result = await _repository.InsertRecordAsync<Sedan>(record);
        return result.Id;
    }
}