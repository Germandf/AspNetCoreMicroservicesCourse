using AspnetRunBasics.Extensions;
using AspnetRunBasics.Models;

namespace AspnetRunBasics.Services;

public class CatalogService : ICatalogService
{
    private readonly HttpClient _client;

    public CatalogService(HttpClient client)
    {
        _client = client;
    }

    public async Task<CatalogModel> CreateCatalog(CatalogModel model)
    {
        var response = await _client.PostAsJson("Catalog", model);

        if (response.IsSuccessStatusCode)
        {
            return await response.ReadContentAs<CatalogModel>();
        }
        else
        {
            throw new Exception("Something went wrong when calling the api.");
        }
    }

    public async Task<IEnumerable<CatalogModel>> GetCatalogs()
    {
        var response = await _client.GetAsync("/Catalog");
        return await response.ReadContentAs<IEnumerable<CatalogModel>>();
    }

    public async Task<CatalogModel> GetCatalog(string id)
    {
        var response = await _client.GetAsync($"/Catalog/{id}");
        return await response.ReadContentAs<CatalogModel>();
    }

    public async Task<IEnumerable<CatalogModel>> GetCatalogsByCategory(string category)
    {
        var response = await _client.GetAsync($"/Catalog/GetProductsByCategory{category}");
        return await response.ReadContentAs<IEnumerable<CatalogModel>>();
    }
}
