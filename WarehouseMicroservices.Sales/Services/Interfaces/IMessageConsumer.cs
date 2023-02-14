namespace WarehouseMicroservices.Sales.Services.Interfaces
{
    public interface IMessageConsumer
    {
        Task RegisterOnMessageHandlerAndReceiveMessages();
        Task CloseQueueAsync();
        ValueTask DisposeAsync();
    }
}
