using CarAuctionSystem.Application.Common.Constants;
using CarAuctionSystem.Application.Vehicles.Commands.Common;
using FluentValidation;

namespace CarAuctionSystem.Application.Vehicles.Commands.CreateSUV;

public class CreateSUVCommandValidator : BaseCreateVehicleCommandValidator<CreateSUVCommand>
{
    public CreateSUVCommandValidator()
    {
        RuleFor(v => v.NumberOfSeats).NotEmpty();
        RuleFor(v => v.NumberOfSeats).GreaterThanOrEqualTo(VehicleConstants.MinSeats);
        RuleFor(v => v.NumberOfSeats).LessThanOrEqualTo(VehicleConstants.MaxSeats);
    }
}