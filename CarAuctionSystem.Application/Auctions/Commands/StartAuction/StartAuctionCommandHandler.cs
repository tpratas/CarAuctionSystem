using AutoMapper;
using CarAuctionSystem.Domain.Entities.Vehicles;
using CarAuctionSystem.Application.Common.Interfaces.Repositories;
using CarAuctionSystem.Application.Common.Errors;
using ErrorOr;
using MediatR;
using CarAuctionSystem.Domain.Entities;

namespace CarAuctionSystem.Application.Auctions.Commands.StartAuction;

public class StartAuctionCommandHandler : IRequestHandler<StartAuctionCommand, ErrorOr<Guid>>
{
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IAuctionRepository _auctionRepository;
    private readonly IMapper _mapper;

    public StartAuctionCommandHandler(
        IVehicleRepository vehicleRepository,
        IAuctionRepository auctionRepository,
        IMapper mapper)
    {
        _vehicleRepository = vehicleRepository ?? throw new ArgumentNullException();
        _auctionRepository = auctionRepository ?? throw new ArgumentNullException();
        _mapper = mapper ?? throw new ArgumentNullException();
    }

    public async Task<ErrorOr<Guid>> Handle(StartAuctionCommand request, CancellationToken cancellationToken)
    {
        var vehicle = await _vehicleRepository.LoadRecordByIdAsync<Vehicle>(request.VehicleId);

        if (vehicle == null)
        {
            return Errors.Vehicles.NotFound;
        }

        if (await _auctionRepository.ExistsForVehicleAsync<Vehicle>(request.VehicleId))
        {
            return Errors.Vehicles.AlreadyInAuction;
        }

        var record = CreateAuction(vehicle);
        await _auctionRepository.InsertRecordAsync<Auction>(record);

        return record.Id;
    }

    private Auction CreateAuction(Vehicle vehicle)
    {
        return new Auction()
        {
            StartDate = DateTime.UtcNow,
            Item = vehicle
        };
    }
}




