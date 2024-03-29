﻿using Microsoft.Extensions.Logging;
using Ordering.Domain.Entities;

namespace Ordering.Infrastructure.Persistence;

public class OrderContextSeed
{
    public static async Task SeedAsync(OrderContext orderContext, ILogger<OrderContextSeed> logger)
    {
        if (orderContext.Orders.Any() is false)
        {
            await orderContext.Orders.AddRangeAsync(GetPreconfiguredOrders());
            await orderContext.SaveChangesAsync();
            logger.LogInformation("Seed database associated with context {DbContextName}", typeof(OrderContext).Name);
        }
    }

    private static IEnumerable<Order> GetPreconfiguredOrders()
    {
        return new List<Order>
        {
            new Order
            {
                UserName = "german", 
                FirstName = "Germán",
                LastName = "De Francesco", 
                EmailAddress = "fakeemail@domain.com", 
                AddressLine = "Fake Street 123", 
                Country = "Argentina", 
                TotalPrice = 350 
            },
        };
    }
}
