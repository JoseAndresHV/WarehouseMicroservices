namespace WarehouseMicroservices.Inventory.DTOs.Product
{
    public record CreateProductDTO
    {
        public string ProductName { get; init; } = null!;
        public string? Description { get; init; }
        public string Category { get; init; } = null!;
        public string Unit { get; init; } = null!;
        public int Stock { get; init; }
        public decimal Price { get; init; }
    }
}
