using MediatR;

// Namespace is different from the other code because RabbitMQ requires even the namespaces to be identical for the messages. :)
namespace Shared.Events
{
    public record ThreadCreatedNotification : INotification
    {
        public Guid Id { get; init; }
        public Guid ForumId { get; init; }
    }
}
