using WarehouseMicroservices.Sales.Enums;

namespace WarehouseMicroservices.Sales.DTOs.Sale
{
    public record UpdateSaleStatusDTO
    {
        public int Id { get; init; }
        public OrderStatus Status { get; init; }
    }
}
