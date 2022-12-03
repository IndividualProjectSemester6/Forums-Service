using MassTransit;
using Shared.Events;

namespace ForumsService.Application.Messaging.Consumers
{
    public class ThreadCreatedConsumer : IConsumer<ThreadCreatedNotification>
    {
        public async Task Consume(ConsumeContext<ThreadCreatedNotification> context)
        {
            var message = context.Message;
            await Console.Out.WriteLineAsync($"Message from Producer : {message}");
        }
    }
}
