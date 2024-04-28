using CarAuctionSystem.Domain.Common;

namespace CarAuctionSystem.Application.Common.Interfaces.Repositories;

public interface IBaseRepository
{
    Task<T> InsertRecordAsync<T>(T record) where T : BaseEntity;
    Task<IList<T>> LoadRecordsAsync<T>();
    Task<T> LoadRecordByIdAsync<T>(Guid id);
    Task<bool> ExistsAsync<T>(Guid id); 
    Task<T> UpsertRecordAsync<T>(T record);
    Task DeleteRecordAsync<T>(Guid id);
}
