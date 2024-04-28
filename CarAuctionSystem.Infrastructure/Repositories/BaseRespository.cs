using CarAuctionSystem.Application.Common.Interfaces.Repositories;
using CarAuctionSystem.Domain.Common;

namespace CarAuctionSystem.Infrastructure.Repositories;

public abstract class BaseRespository: IBaseRepository
{
    private readonly string _database = string.Empty;
    private readonly string _table = string.Empty;

    public BaseRespository(string database, string table) 
    {
        _database = database;
        _table = table;
    }

    public async Task<T> InsertRecordAsync<T>(T record) where T : BaseEntity
    {
        throw new NotImplementedException();
    }

    public async Task<IList<T>> LoadRecordsAsync<T>()
    {
        throw new NotImplementedException();
    }
    public async Task<T> LoadRecordByIdAsync<T>(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> ExistsAsync<T>(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<T> UpsertRecordAsync<T>(T record)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteRecordAsync<T>(Guid id)
    {
        throw new NotImplementedException();
    }
}
