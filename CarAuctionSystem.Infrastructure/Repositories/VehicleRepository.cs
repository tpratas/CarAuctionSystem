using CarAuctionSystem.Application.Common.Interfaces.Repositories;
using CarAuctionSystem.Domain.Entities.Vehicles;
using CarAuctionSystem.Infrastructure.Options;
using Microsoft.Extensions.Options;

namespace CarAuctionSystem.Infrastructure.Repositories;

public class VehicleRepository : BaseRespository, IVehicleRepository
{
    public VehicleRepository(IOptions<DatabaseOptions> options) 
        : base(options.Value.DatabaseName, options.Value.VehicleTableName)
    {}

    public async Task<bool> ExistsVINAsync(string vin)
    {
        throw new NotImplementedException();
    }

    public async Task<IList<Vehicle>> SearchAsync(
        string typeId,
        string manufacturerId,
        string modelId,
        int? year,
        decimal? startingBid,
        int? pageNumber = 1,
        int? pageSize = 10)
    {
        throw new NotImplementedException();
    }

    
}
