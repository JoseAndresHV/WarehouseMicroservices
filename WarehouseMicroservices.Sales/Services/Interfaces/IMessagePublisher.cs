namespace WarehouseMicroservices.Sales.Services.Interfaces
{
    public interface IMessagePublisher
    {
        public Task Publish<T>(string topic, T data);
    }
}
