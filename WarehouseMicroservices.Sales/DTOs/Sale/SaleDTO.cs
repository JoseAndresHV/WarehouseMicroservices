namespace WarehouseMicroservices.Sales.DTOs.Sale
{
    public record SaleDTO
    {
        public int Id { get; init; }
        public int ProductId { get; init; }
        public int Qty { get; init; }
        public decimal Subtotal { get; init; }
        public decimal Tax { get; init; }
        public decimal Total { get; init; }
        public DateTime DateTime { get; init; }
    }
}
