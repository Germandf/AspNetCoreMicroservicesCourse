namespace Shopping.Aggregator.Models;

public class BasketModel
{
    public required string UserName { get; set; }
    public required List<BasketItemExtendedModel> Items { get; set; } = new();
    public required decimal TotalPrice { get; set; }
}
