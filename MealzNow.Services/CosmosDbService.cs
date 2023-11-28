using FoodsNow.Core;
using MealzNow.Services;
using Microsoft.Azure.Cosmos;

public class CosmosDbService : ICosmosDbService
{
    private Container _container;

    public CosmosDbService(
        CosmosClient cosmosDbClient,
        string databaseName,
        string containerName)
    {
        _container = cosmosDbClient.GetContainer(databaseName, containerName);
    }

    public async Task AddAsync(CurrentAppUser item)
    {
        await _container.CreateItemAsync(item, new PartitionKey(item.Id));
    }

    public async Task DeleteAsync(string id)
    {
        await _container.DeleteItemAsync<CurrentAppUser>(id, new PartitionKey(id));
    }

    public async Task<CurrentAppUser> GetAsync(string id)
    {
        try
        {
            var response = await _container.ReadItemAsync<CurrentAppUser>(id, new PartitionKey(id));
            return response.Resource;
        }
        catch (CosmosException) //For handling item not found and other exceptions
        {
            return null;
        }
    }

    public async Task<IEnumerable<CurrentAppUser>> GetMultipleAsync(string queryString)
    {
        var query = _container.GetItemQueryIterator<CurrentAppUser>(new QueryDefinition(queryString));

        var results = new List<CurrentAppUser>();
        while (query.HasMoreResults)
        {
            var response = await query.ReadNextAsync();
            results.AddRange(response.ToList());
        }

        return results;
    }

    public async Task UpdateAsync(string id, CurrentAppUser item)
    {
        await _container.UpsertItemAsync(item, new PartitionKey(id));
    }
}