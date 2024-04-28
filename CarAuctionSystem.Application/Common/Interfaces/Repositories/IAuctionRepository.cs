using CarAuctionSystem.Domain.Entities;

namespace CarAuctionSystem.Application.Common.Interfaces.Repositories;

public interface IAuctionRepository: IBaseRepository 
{
    Task<bool> ExistsForVehicleAsync<T>(Guid id);
    Task<bool> InsertBidAsync(Bid bid, Guid auctionId);
}
