using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using System.Text;
using WarehouseMicroservices.Sales.Services.Interfaces;

namespace WarehouseMicroservices.Sales.Services.Implementations
{
    public class MessagePublisher : IMessagePublisher
    {
        private readonly ServiceBusClient _busClient;

        public MessagePublisher(ServiceBusClient _busClient)
        {
            this._busClient = _busClient;
        }

        public async Task Publish<T>(string topic, T data)
        {
            var sender = _busClient.CreateSender(topic);

            var objAsText = JsonConvert.SerializeObject(data);
            var message = new ServiceBusMessage(Encoding.UTF8.GetBytes(objAsText));

            try
            {
                await sender.SendMessageAsync(message);
            }
            finally
            {
                await sender.DisposeAsync();
            }
        }
    }
}
