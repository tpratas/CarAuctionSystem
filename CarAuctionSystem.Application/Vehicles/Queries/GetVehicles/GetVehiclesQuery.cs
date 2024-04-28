using CarAuctionSystem.Application.Vehicles.Queries.GetVehicles.Dtos;
using ErrorOr;
using MediatR;

namespace CarAuctionSystem.Application.Vehicles.Queries.GetVehicles;

public record GetVehiclesQuery(
    string TypeId,
    string ManufacturerId,
    string ModelId,
    int? Year,
    decimal? StartingBid,
    int? pageNumber = 1,
    int? pageSize = 10) : IRequest<ErrorOr<IList<VehicleDto>>>;