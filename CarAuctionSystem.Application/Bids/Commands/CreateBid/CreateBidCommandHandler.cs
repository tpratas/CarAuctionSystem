using AutoMapper;
using CarAuctionSystem.Domain.Entities.Vehicles;
using CarAuctionSystem.Application.Common.Interfaces.Repositories;
using CarAuctionSystem.Application.Common.Errors;
using ErrorOr;
using MediatR;
using CarAuctionSystem.Domain.Entities;
using CarAuctionSystem.Application.Auctions.Commands.StartAuction;

namespace CarAuctionSystem.Application.Bids.Commands.CreateBid;

public class CreateBidCommandHandler : IRequestHandler<CreateBidCommand, ErrorOr<Guid>>
{
    private readonly IAuctionRepository _auctionRepository;
    private readonly IMapper _mapper;

    public CreateBidCommandHandler(
        IAuctionRepository auctionRepository,
        IMapper mapper)
    {
        _auctionRepository = auctionRepository ?? throw new ArgumentNullException();
        _mapper = mapper ?? throw new ArgumentNullException();
    }

    public async Task<ErrorOr<Guid>> Handle(CreateBidCommand request, CancellationToken cancellationToken)
    {
        var auction = await _auctionRepository.LoadRecordByIdAsync<Auction>(request.AuctionId);

        if (auction == null)
        {
            return Errors.Auctions.NotFound;
        }

        if (auction.Item == null)
        {
            return Errors.Auctions.ItemNotFound;
        }

        if(auction.Item.StartingBid > request.BidAmount)
        {
            return Errors.Auctions.InvalidBid;
        }

        var record = CreateBid(request.BidAmount);
        await _auctionRepository.InsertBidAsync(record, request.AuctionId);

        return record.Id;
    }

    private Bid CreateBid(decimal amount)
    {
      return new Bid()
        {
            Id = Bid.CreateNewId(),
            Amount = amount
        };
    }
}




