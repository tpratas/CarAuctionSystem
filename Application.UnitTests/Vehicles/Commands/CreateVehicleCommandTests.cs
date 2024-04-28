namespace Application.UnitTests.Vehicles.Commands
{
    using System;
    using System.Threading.Tasks;
    using AutoMapper;
    using CarAuctionSystem.Application.Common.Interfaces.Repositories;
    using CarAuctionSystem.Application.Vehicles.Commands.Common;
    using CarAuctionSystem.Application.Vehicles.Commands.CreateHatchback;
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;
    using Moq;
    using Xunit;

    public class CreateVehicleCommandTests 
    {
        private static IServiceProvider _serviceProvider = null;
        private static IServiceCollection _services = null;

        public CreateVehicleCommandTests()
        {
            //var dateTimeMock = new Mock<IDateTime>();
            //dateTimeMock.Setup(x => x.UtcNow).Returns(DateTime.UtcNow);
            //dateTimeMock.Setup(x => x.Now).Returns(DateTime.Now);
            //this.dateTime = dateTimeMock.Object;

            //this.currentUserServiceMock = new Mock<ICurrentUserService>();
            //this.currentUserServiceMock
            //    .Setup(x => x.UserId)
            //    .Returns(DataConstants.SampleUserId);

            //_services = new ServiceCollection();


            //var mockRepository = new Mock<IVehicleRepository>();
            //var mockMapper = new Mock<IMapper>();
            //this.handler = new CreateHatchbackCommandHandler(mockRepository.Object, mockMapper.Object);
                //this.Context, this.currentUserServiceMock.Object, this.dateTime, this.Mapper);
        }

        //[Fact]
        //public async Task Handle_Given_Model_With_WrongItemId_Should_Throw_NotFoundException()
        //{
        //    var command = new CreateBidCommand
        //    { Amount = 1000, ItemId = Guid.Empty, UserId = DataConstants.SampleUserId };
        //    await Assert.ThrowsAsync<NotFoundException>(() => this.handler.Handle(command, CancellationToken.None));
        //}

        //public static IEnumerable<object[]> BaseVehicleCommandData =>
        //new List<object[]>
        //{
        //    new object[] { string.Empty, 2018, Guid.NewGuid().ToString(), nameof(TypeCommand.Name), Guid.NewGuid().ToString(), nameof(ManufacturerCommand.Name),Guid.NewGuid().ToString(), nameof(ModelCommand.Name), 1000, Guid.NewGuid().ToString(), nameof(AuctionUserCommand.Name)},
        //    new object[] { nameof(BaseCreateVehicleCommand.VIN), 0, Guid.NewGuid().ToString(), nameof(TypeCommand.Name), Guid.NewGuid().ToString(), nameof(ManufacturerCommand.Name),Guid.NewGuid().ToString(), nameof(ModelCommand.Name), 1000, Guid.NewGuid().ToString(), nameof(AuctionUserCommand.Name)},
        //    new object[] { nameof(BaseCreateVehicleCommand.VIN), DateTime.Now.Year +1, Guid.NewGuid().ToString(), nameof(TypeCommand.Name), Guid.NewGuid().ToString(), nameof(ManufacturerCommand.Name),Guid.NewGuid().ToString(), nameof(ModelCommand.Name), 1000, Guid.NewGuid().ToString(), nameof(AuctionUserCommand.Name)},
        //    new object[] { nameof(BaseCreateVehicleCommand.VIN), 2018, string.Empty, string.Empty, Guid.NewGuid().ToString(), nameof(ManufacturerCommand.Name),Guid.NewGuid().ToString(), nameof(ModelCommand.Name), 1000, Guid.NewGuid().ToString(), nameof(AuctionUserCommand.Name)},
        //    new object[] { nameof(BaseCreateVehicleCommand.VIN), 2018, Guid.NewGuid().ToString(), nameof(TypeCommand.Name), string.Empty, string.Empty,Guid.NewGuid().ToString(), nameof(ModelCommand.Name), 1000, Guid.NewGuid().ToString(), nameof(AuctionUserCommand.Name)},
        //    new object[] { nameof(BaseCreateVehicleCommand.VIN), 2018, Guid.NewGuid().ToString(), nameof(TypeCommand.Name), Guid.NewGuid().ToString(), nameof(ManufacturerCommand.Name),string.Empty, string.Empty, 1000, Guid.NewGuid().ToString(), nameof(AuctionUserCommand.Name)},
        //    new object[] { nameof(BaseCreateVehicleCommand.VIN), 2018, Guid.NewGuid().ToString(), nameof(TypeCommand.Name), Guid.NewGuid().ToString(), nameof(ManufacturerCommand.Name),Guid.NewGuid().ToString(), nameof(ModelCommand.Name), 0, Guid.NewGuid().ToString(), nameof(AuctionUserCommand.Name)},
        //    new object[] { nameof(BaseCreateVehicleCommand.VIN), 2018, Guid.NewGuid().ToString(), nameof(TypeCommand.Name), Guid.NewGuid().ToString(), nameof(ManufacturerCommand.Name),Guid.NewGuid().ToString(), nameof(ModelCommand.Name), 1000, string.Empty, string.Empty}

        //};

        //public static async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
        //{
        //    var mediator = _serviceProvider.GetRequiredService<IMediator>();

        //    var result = await mediator.Send(request);
        //    return result;
        //}

        //[Theory, MemberData(nameof(BaseVehicleCommandData))]
        //public async Task Handle_Given_BaseModel_With_WrongValidation(
        //    string vin,
        //    int year,
        //    string typeId,
        //    string typeName,
        //    string manufacturerId,
        //    string manufacturerName,
        //    string modelId,
        //    string modelName,
        //    decimal startingBid,
        //    string ownerId,
        //    string ownerName)
        //{
        //    var command = new CreateHatchbackCommand() { VIN = vin, Year = year, StartingBid = startingBid };
        //    if(!string.IsNullOrEmpty(typeId) || !string.IsNullOrEmpty(typeName))
        //    {
        //        command.Type = new TypeCommand(Guid.Parse(typeId), typeName);
        //    }
        //    if (!string.IsNullOrEmpty(manufacturerId) || !string.IsNullOrEmpty(manufacturerName))
        //    {
        //        command.Manufacturer = new ManufacturerCommand(Guid.Parse(manufacturerId), manufacturerName);
        //    }
        //    if (!string.IsNullOrEmpty(modelId) || !string.IsNullOrEmpty(modelName))
        //    {
        //        command.Model = new ModelCommand(Guid.Parse(modelId), modelName);
        //    }
        //    if (!string.IsNullOrEmpty(ownerId) || !string.IsNullOrEmpty(ownerName))
        //    {
        //        command.Owner = new AuctionUserCommand(Guid.Parse(ownerId), ownerName);
        //    }

        //    var _serviceProvider = _services
               
        //       .AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateHatchbackCommandHandler).Assembly))
        //       .AddTransient(provider => Mock.Of<IVehicleRepository>())
        //       .AddTransient(provider => Mock.Of<IMapper>())
        //       .BuildServiceProvider();

        //    var x = await SendAsync(command);
        //    await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<ValidationException>();


        //    //Assert.True(result.IsError);
        //    //Assert.NotEmpty(result.Errors);
        //    //Assert.All(result.Errors, error => Assert.Equal(ErrorType.Validation, error.Type));
        //}

       
    }
}