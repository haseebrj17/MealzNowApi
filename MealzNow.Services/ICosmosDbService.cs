using FoodsNow.Core;

namespace MealzNow.Services;

public interface ICosmosDbService
{
    Task<IEnumerable<CurrentAppUser>> GetMultipleAsync(string query);
    Task<CurrentAppUser> GetAsync(string id);
    Task AddAsync(CurrentAppUser item);
    Task UpdateAsync(string id, CurrentAppUser item);
    Task DeleteAsync(string id);
}