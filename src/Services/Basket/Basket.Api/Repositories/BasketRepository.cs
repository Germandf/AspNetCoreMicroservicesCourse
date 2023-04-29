using Basket.Api.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Basket.Api.Repositories;

public class BasketRepository : IBasketRepository
{
    private readonly IDistributedCache _distributedCache;

    public BasketRepository(IDistributedCache distributedCache)
    {
        _distributedCache = distributedCache;
    }

    public async Task DeleteBasket(string userName)
    {
        await _distributedCache.RemoveAsync(userName);
    }

    public async Task<ShoppingCart?> GetBasket(string userName)
    {
        var basket = await _distributedCache.GetStringAsync(userName);

        if (string.IsNullOrEmpty(basket))
        {
            return null;
        }

        return JsonConvert.DeserializeObject<ShoppingCart>(basket);
    }

    public async Task<ShoppingCart> UpdateBasket(ShoppingCart basket)
    {
        await _distributedCache.SetStringAsync(basket.UserName, JsonConvert.SerializeObject(basket));
        return (await GetBasket(basket.UserName))!;
    }
}
