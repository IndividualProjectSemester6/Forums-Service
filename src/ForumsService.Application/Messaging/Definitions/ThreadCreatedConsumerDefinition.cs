using ForumsService.Application.Messaging.Consumers;
using MassTransit;

namespace ForumsService.Application.Messaging.Definitions
{
    public class ThreadCreatedConsumerDefinition : ConsumerDefinition<ThreadCreatedConsumer>
    {
        public ThreadCreatedConsumerDefinition()
        {
            // Override default endpoint:
            EndpointName = "thread-created-queue";

            // Limit concurrent messages consumed for the consumer:
            ConcurrentMessageLimit = 8;
        }

        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<ThreadCreatedConsumer> consumerConfigurator)
        {
            // Message retries with intervals in ms:
            endpointConfigurator.UseMessageRetry(r => r.Intervals(100,200,500,800,1000));
            
            //Prevent duplicate events from being published:
            endpointConfigurator.UseInMemoryOutbox();
        }
    }
}
