namespace Application.UnitTests.Vehicles.Commands;

using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CarAuctionSystem.Application.Common.Errors;
using CarAuctionSystem.Application.Common.Interfaces.Repositories;
using CarAuctionSystem.Application.Vehicles.Commands.CreateHatchback;
using ErrorOr;
using Moq;
using Xunit;

public class CreateHatchbackCommandTests 
{
    [Fact]
    public async Task Handle_Existing_Hatchback_On_Inventory()
    {
        var mockRepository = new Mock<IVehicleRepository>();
        mockRepository
            .Setup(x => x.ExistsVINAsync(It.IsAny<string>()))
            .ReturnsAsync(true);

        var mockMapper = new Mock<IMapper>();
        var handler = new CreateHatchbackCommandHandler(mockRepository.Object, mockMapper.Object);
        var command = new CreateHatchbackCommand();
        var result = await handler.Handle(command, CancellationToken.None);
       
        Assert.True(result.IsError);
        Assert.NotEmpty(result.Errors);
        Assert.Equal(ErrorType.Conflict, result.FirstError.Type);
        Assert.Equal(Errors.Vehicles.DuplicateId.Code, result.FirstError.Code);
    }
}