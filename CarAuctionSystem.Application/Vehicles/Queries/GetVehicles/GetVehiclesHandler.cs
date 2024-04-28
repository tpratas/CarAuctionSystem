using AutoMapper;
using CarAuctionSystem.Application.Common.Interfaces.Repositories;
using CarAuctionSystem.Application.Vehicles.Queries.GetVehicles.Dtos;
using ErrorOr;
using MediatR;

namespace CarAuctionSystem.Application.Vehicles.Queries.GetVehicles;

public class GetVehiclesHandler : IRequestHandler<GetVehiclesQuery, ErrorOr<IList<VehicleDto>>>
{
    private readonly IVehicleRepository _repository;
    private readonly IMapper _mapper;

    public GetVehiclesHandler(
        IVehicleRepository repository,
        IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException();
        _mapper = mapper ?? throw new ArgumentNullException();
    }

    public async Task<ErrorOr<IList<VehicleDto>>> Handle(GetVehiclesQuery request, CancellationToken cancellationToken)
    {
        var results = await _repository.SearchAsync(
            request.TypeId,
            request.ManufacturerId,
            request.ModelId,
            request.Year,
            request.StartingBid);
        

        return _mapper.Map<List<VehicleDto>>(results);
    }
}