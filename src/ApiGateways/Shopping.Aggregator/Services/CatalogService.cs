using Shopping.Aggregator.Extensions;
using Shopping.Aggregator.Models;

namespace Shopping.Aggregator.Services;

public class CatalogService : ICatalogService
{
    private readonly HttpClient _client;

    public CatalogService(HttpClient client)
    {
        _client = client;
    }

    public async Task<CatalogModel> GetCatalog(string id)
    {
        var response = await _client.GetAsync($"/api/v1/Catalog/{id}");
        return await response.ReadContentAs<CatalogModel>();
    }

    public async Task<IEnumerable<CatalogModel>> GetCatalogs()
    {
        var response = await _client.GetAsync("/api/v1/Catalog");
        return await response.ReadContentAs<IEnumerable<CatalogModel>>();
    }

    public async Task<IEnumerable<CatalogModel>> GetCatalogsByCategory(string category)
    {
        var response = await _client.GetAsync($"/api/v1/Catalog/GetProductsByCategory/{category}");
        return await response.ReadContentAs<IEnumerable<CatalogModel>>();
    }
}
