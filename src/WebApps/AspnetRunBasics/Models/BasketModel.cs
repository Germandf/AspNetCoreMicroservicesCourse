namespace AspnetRunBasics.Models;

public class BasketModel
{
    public required string UserName { get; set; }
    public required List<BasketItemModel> Items { get; set; } = new();
    public required decimal TotalPrice { get; set; }
}
