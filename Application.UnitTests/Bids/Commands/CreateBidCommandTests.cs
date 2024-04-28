namespace Application.UnitTests.Bids.Commands;

using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CarAuctionSystem.Application.Auctions.Commands.CloseAuction;
using CarAuctionSystem.Application.Bids.Commands.CreateBid;
using CarAuctionSystem.Application.Common.Errors;
using CarAuctionSystem.Application.Common.Interfaces.Repositories;
using CarAuctionSystem.Domain.Entities;
using CarAuctionSystem.Domain.Entities.Vehicles;
using ErrorOr;
using Moq;
using Xunit;

public class CreateBidCommandTests
{
    [Fact]
    public async Task Handle_Create_Bid_When_Auction_Not_Found()
    {
        var mockAuctionRepository = new Mock<IAuctionRepository>();
        mockAuctionRepository.Setup(x => x.LoadRecordByIdAsync<Auction>(It.IsAny<Guid>()));

        var mockMapper = new Mock<IMapper>();
        var handler = new CreateBidCommandHandler(mockAuctionRepository.Object, mockMapper.Object);
        var command = new CreateBidCommand();
        var result = await handler.Handle(command, CancellationToken.None);

        Assert.True(result.IsError);
        Assert.NotEmpty(result.Errors);
        Assert.Equal(ErrorType.NotFound, result.FirstError.Type);
        Assert.Equal(Errors.Auctions.NotFound.Code, result.FirstError.Code);
    }

    [Fact]
    public async Task Handle_Create_Bid_When_Item_Not_Found()
    {
        var mockAuctionRepository = new Mock<IAuctionRepository>();
        mockAuctionRepository
            .Setup(x => x.LoadRecordByIdAsync<Auction>(It.IsAny<Guid>()))
            .ReturnsAsync(new Auction());

        var mockMapper = new Mock<IMapper>();
        var handler = new CreateBidCommandHandler(mockAuctionRepository.Object, mockMapper.Object);
        var command = new CreateBidCommand();
        var result = await handler.Handle(command, CancellationToken.None);

        Assert.True(result.IsError);
        Assert.NotEmpty(result.Errors);
        Assert.Equal(ErrorType.NotFound, result.FirstError.Type);
        Assert.Equal(Errors.Auctions.ItemNotFound.Code, result.FirstError.Code);
    }

    [Fact]
    public async Task Handle_Create_Bid_When_Amount_Is_Invalid()
    {
        var mockAuctionRepository = new Mock<IAuctionRepository>();
        mockAuctionRepository
            .Setup(x => x.LoadRecordByIdAsync<Auction>(It.IsAny<Guid>()))
            .ReturnsAsync(new Auction() { Item = new Vehicle() { StartingBid = 10000 } });

        var mockMapper = new Mock<IMapper>();
        var handler = new CreateBidCommandHandler(mockAuctionRepository.Object, mockMapper.Object);
        var command = new CreateBidCommand() { BidAmount = 9000 };
        var result = await handler.Handle(command, CancellationToken.None);

        Assert.True(result.IsError);
        Assert.NotEmpty(result.Errors);
        Assert.Equal(ErrorType.Conflict, result.FirstError.Type);
        Assert.Equal(Errors.Auctions.InvalidBid.Code, result.FirstError.Code);
    }
}