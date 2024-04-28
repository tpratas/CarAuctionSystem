namespace Application.UnitTests.Auctions.Commands;

using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CarAuctionSystem.Application.Auctions.Commands.CloseAuction;
using CarAuctionSystem.Application.Common.Errors;
using CarAuctionSystem.Application.Common.Interfaces.Repositories;
using CarAuctionSystem.Domain.Entities;
using ErrorOr;
using Moq;
using Xunit;

public class CloseAuctionCommandTests
{
    [Fact]
    public async Task Handle_Close_Action_When_Auction_Not_Found()
    {
        var mockAuctionRepository = new Mock<IAuctionRepository>();
        mockAuctionRepository.Setup(x => x.LoadRecordByIdAsync<Auction>(It.IsAny<Guid>()));

        var mockMapper = new Mock<IMapper>();
        var handler = new CloseAuctionCommandHandler(mockAuctionRepository.Object, mockMapper.Object);
        var command = new CloseAuctionCommand();
        var result = await handler.Handle(command, CancellationToken.None);
       
        Assert.True(result.IsError);
        Assert.NotEmpty(result.Errors);
        Assert.Equal(ErrorType.NotFound, result.FirstError.Type);
        Assert.Equal(Errors.Auctions.NotFound.Code, result.FirstError.Code);
    }
}