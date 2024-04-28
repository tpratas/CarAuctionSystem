using CarAuctionSystem.Domain.Entities.Vehicles;

namespace CarAuctionSystem.Application.Common.Interfaces.Repositories;

public interface IVehicleRepository: IBaseRepository 
{
    Task<bool> ExistsVINAsync(string vin);

    Task<IList<Vehicle>> SearchAsync(
        string typeId,
        string manufacturerId,
        string modelId,
        int? year,
        decimal? startingBid,
        int? pageNumber = 1,
        int? pageSize = 10);
}
