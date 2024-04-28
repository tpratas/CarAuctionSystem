using CarAuctionSystem.Application.Common.Interfaces.Repositories;
using CarAuctionSystem.Domain.Entities;
using CarAuctionSystem.Infrastructure.Options;
using Microsoft.Extensions.Options;

namespace CarAuctionSystem.Infrastructure.Repositories;

public class AuctionRepository : BaseRespository, IAuctionRepository
{
    public AuctionRepository(IOptions<DatabaseOptions> options) 
        : base(options.Value.DatabaseName, options.Value.AuctionTableName)
    {}

    public async Task<bool> ExistsForVehicleAsync<T>(Guid id)
    {
        throw new NotImplementedException();
    }
    public async Task<bool> InsertBidAsync(Bid bid, Guid auctionId)
    {
        throw new NotImplementedException();
    }
}
