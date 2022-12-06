using MassTransit;
using MassTransit.Mediator;
using Shared.Events;

namespace ForumsService.Application.Messaging.Observers
{
    public class ThreadCreatedObserver : IConsumeObserver
    {
        private readonly IMediator _mediator;

        public ThreadCreatedObserver(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task PreConsume<T>(ConsumeContext<T> context) where T : class
        {
            await Console.Out.WriteLineAsync(context.Message.ToString());
        }

        public async Task PostConsume<T>(ConsumeContext<T> context) where T : class
        {
            dynamic message = context.Message;
            var command = new ThreadCreatedNotification() {Id = message.Id, ForumId = message.ForumId};
            await _mediator.Send(command);
        }

        public async Task ConsumeFault<T>(ConsumeContext<T> context, Exception exception) where T : class
        {
            await Console.Out.WriteLineAsync("Error: " + exception.Message);
        }
    }
}
