using WarehouseMicroservices.Sales.Enums;

namespace WarehouseMicroservices.Sales.DTOs
{
    public record MessageDTO<T>
    {
        public MessageEvent Event { get; init; }
        public T Data { get; init; } = default!;
    }
}
