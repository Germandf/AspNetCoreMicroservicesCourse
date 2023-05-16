namespace Shopping.Aggregator.Models;

public class BasketItemExtendedModel
{
    public required int Quantity { get; set; }
    public required string Color { get; set; }
    public required decimal Price { get; set; }
    public required string ProductId { get; set; }
    public required string ProductName { get; set; }
    public string Category { get; set; } = "";
    public string Summary { get; set; } = "";
    public string Description { get; set; } = "";
    public string ImageFile { get; set; } = "";
}
