namespace WarehouseMicroservices.Inventory.Services.Interfaces
{
    public interface IMessagePublisher
    {
        public Task Publish<T>(string topic, T data);
    }
}
