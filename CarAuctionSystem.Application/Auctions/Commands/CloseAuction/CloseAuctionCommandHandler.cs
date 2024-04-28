using AutoMapper;
using CarAuctionSystem.Application.Common.Interfaces.Repositories;
using CarAuctionSystem.Application.Common.Errors;
using ErrorOr;
using MediatR;
using CarAuctionSystem.Domain.Entities;

namespace CarAuctionSystem.Application.Auctions.Commands.CloseAuction;

public class CloseAuctionCommandHandler : IRequestHandler<CloseAuctionCommand, ErrorOr<Guid>>
{
    private readonly IAuctionRepository _auctionRepository;
    private readonly IMapper _mapper;

    public CloseAuctionCommandHandler(
        IAuctionRepository auctionRepository,
        IMapper mapper)
    {
        _auctionRepository = auctionRepository ?? throw new ArgumentNullException();
        _mapper = mapper ?? throw new ArgumentNullException();
    }

    public async Task<ErrorOr<Guid>> Handle(CloseAuctionCommand request, CancellationToken cancellationToken)
    {
        var record = await _auctionRepository.LoadRecordByIdAsync<Auction>(request.Id);

        if (record == null)
        {
            return Errors.Auctions.NotFound;
        }

        CloseAuction(record);
        await _auctionRepository.UpsertRecordAsync(record);

        return record.Id;
    }

    private void CloseAuction(Auction auction)
    {
        auction.EndDate = DateTime.UtcNow;
        auction.IsActive = false;
    }
}




