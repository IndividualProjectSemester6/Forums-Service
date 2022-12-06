using ForumsService.Domain.Entities;
using MediatR;

namespace ForumsService.Application.Commands.AddThreadToForum
{
    public class AddThreadToForumCommand : IRequest<ForumDto>
    {
        public ThreadDto Thread { get; }
        public Guid ForumId { get; }

        public AddThreadToForumCommand(ThreadDto thread, Guid forumId)
        {
            Thread = thread;
            ForumId = forumId;
        }
    }
}
