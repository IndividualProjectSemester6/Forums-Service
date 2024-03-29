﻿using ForumsService.Application.Commands.AddThreadToForum;
using ForumsService.Domain.Entities;
using MassTransit;
using MediatR;
using Shared.Events;

namespace ForumsService.Application.Messaging.Consumers
{
    public class ThreadCreatedConsumer : IConsumer<ThreadCreatedNotification>
    {
        private readonly IMediator _mediator;

        public ThreadCreatedConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<ThreadCreatedNotification> context)
        {
            var message = context.Message;
            await Console.Out.WriteLineAsync($"Message from Producer : {message}");
            var command = new AddThreadToForumCommand(new ThreadDto() { Id = message.Id }, message.ForumId);
            await _mediator.Send(command);
        }
    }
}
