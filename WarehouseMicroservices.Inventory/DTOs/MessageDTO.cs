using WarehouseMicroservices.Inventory.Enums;

namespace WarehouseMicroservices.Inventory.DTOs
{
    public record MessageDTO<T>
    {
        public MessageEvent Event { get; init; }
        public T Data { get; init; } = default!;
    }
}
