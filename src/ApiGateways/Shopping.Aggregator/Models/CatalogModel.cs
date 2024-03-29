﻿namespace Shopping.Aggregator.Models;

public class CatalogModel
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required string Category { get; set; }
    public required string Summary { get; set; }
    public required string Description { get; set; }
    public required string ImageFile { get; set; }
    public required decimal Price { get; set; }
}
