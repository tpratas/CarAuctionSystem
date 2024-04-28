namespace Application.UnitTests.Auctions.Commands;

using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CarAuctionSystem.Application.Auctions.Commands.StartAuction;
using CarAuctionSystem.Application.Common.Errors;
using CarAuctionSystem.Application.Common.Interfaces.Repositories;
using CarAuctionSystem.Domain.Entities.Vehicles;
using ErrorOr;
using Moq;
using Xunit;

public class StartAuctionCommandTests
{
    [Fact]
    public async Task Handle_Start_Action_When_Vehicle_Not_Found()
    {
        var mockVehicleRepository = new Mock<IVehicleRepository>();
        mockVehicleRepository.Setup(x => x.LoadRecordByIdAsync<Vehicle>(It.IsAny<Guid>()));

        var mockAuctionRepository = new Mock<IAuctionRepository>();
        var mockMapper = new Mock<IMapper>();
        var handler = new StartAuctionCommandHandler(mockVehicleRepository.Object, mockAuctionRepository.Object, mockMapper.Object);
        var command = new StartAuctionCommand();
        var result = await handler.Handle(command, CancellationToken.None);
       
        Assert.True(result.IsError);
        Assert.NotEmpty(result.Errors);
        Assert.Equal(ErrorType.NotFound, result.FirstError.Type);
        Assert.Equal(Errors.Vehicles.NotFound.Code, result.FirstError.Code);
    }

    [Fact]
    public async Task Handle_Start_Action_When_Vehicle_Already_In_Auction()
    {
        var mockVehicleRepository = new Mock<IVehicleRepository>();
        mockVehicleRepository
            .Setup(x => x.LoadRecordByIdAsync<Vehicle>(It.IsAny<Guid>()))
            .ReturnsAsync(new Vehicle());

        var mockAuctionRepository = new Mock<IAuctionRepository>();
        mockAuctionRepository
            .Setup(x => x.ExistsForVehicleAsync<Vehicle>(It.IsAny<Guid>()))
            .ReturnsAsync(true);

        var mockMapper = new Mock<IMapper>();
        var handler = new StartAuctionCommandHandler(mockVehicleRepository.Object, mockAuctionRepository.Object, mockMapper.Object);
        var command = new StartAuctionCommand();
        var result = await handler.Handle(command, CancellationToken.None);

        Assert.True(result.IsError);
        Assert.NotEmpty(result.Errors);
        Assert.Equal(ErrorType.Conflict, result.FirstError.Type);
        Assert.Equal(Errors.Vehicles.AlreadyInAuction.Code, result.FirstError.Code);
    }
}