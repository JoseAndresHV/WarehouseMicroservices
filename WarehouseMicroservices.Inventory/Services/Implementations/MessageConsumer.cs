using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using System.Text;
using WarehouseMicroservices.Inventory.Data;
using WarehouseMicroservices.Inventory.DTOs;
using WarehouseMicroservices.Inventory.Enums;
using WarehouseMicroservices.Inventory.Models;
using WarehouseMicroservices.Inventory.Services.Interfaces;

namespace WarehouseMicroservices.Inventory.Services.Implementations
{
    public class MessageConsumer : IMessageConsumer
    {
        private readonly ServiceBusClient _busClient;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ServiceBusProcessor _processor;
        public MessageConsumer(ServiceBusClient busClient, IServiceScopeFactory scopeFactory)
        {
            _busClient = busClient;
            _scopeFactory = scopeFactory;
            _processor = _busClient.CreateProcessor("SalesProductChanged", "inventory",
                new ServiceBusProcessorOptions
                {
                    MaxConcurrentCalls = 1,
                    AutoCompleteMessages = false,
                }); ;
        }

        public async Task RegisterOnMessageHandlerAndReceiveMessages()
        {
            _processor.ProcessMessageAsync += ProcessMessagesAsync;
            _processor.ProcessErrorAsync += ProcessErrorAsync;
            await _processor.StartProcessingAsync().ConfigureAwait(false);
        }

        private Task ProcessErrorAsync(ProcessErrorEventArgs arg)
        {
            //Add exception or log
            return Task.CompletedTask;
        }

        private async Task ProcessMessagesAsync(ProcessMessageEventArgs args)
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            var body = args.Message.Body;
            var message = JsonConvert.DeserializeObject<MessageDTO<Product>>(Encoding.UTF8.GetString(body));

            switch (message!.Event)
            {
                case MessageEvent.ProductSold:
                    context.Products.Update(message.Data);
                    break;

                case MessageEvent.ProductRefund:
                    context.Products.Update(message.Data);
                    break;
            }

            await context.SaveChangesAsync();
            await args.CompleteMessageAsync(args.Message).ConfigureAwait(false);
        }

        public async ValueTask DisposeAsync()
        {
            if (_processor != null)
            {
                await _processor.DisposeAsync().ConfigureAwait(false);
            }

            if (_busClient != null)
            {
                await _busClient.DisposeAsync().ConfigureAwait(false);
            }
        }

        public async Task CloseQueueAsync()
        {
            await _processor.CloseAsync().ConfigureAwait(false);
        }
    }
}
