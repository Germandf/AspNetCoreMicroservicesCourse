namespace Shopping.Aggregator.Models;

public class BasketItemExtendedModel
{
    public required int Quantity { get; set; }
    public required string Color { get; set; }
    public required decimal Price { get; set; }
    public required string ProductId { get; set; }
    public required string ProductName { get; set; }
    public required string Category { get; set; }
    public required string Summary { get; set; }
    public required string Description { get; set; }
    public required string ImageFile { get; set; }
}
