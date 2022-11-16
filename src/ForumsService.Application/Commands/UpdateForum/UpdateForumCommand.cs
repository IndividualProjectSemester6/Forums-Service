using ForumsService.Domain.Entities;
using MediatR;

namespace ForumsService.Application.Commands.UpdateForum
{
    public class UpdateForumCommand : IRequest<ForumDto>
    {
        public ForumDto ExistingForum { get; }

        public UpdateForumCommand(ForumDto existingForum)
        {
            ExistingForum = existingForum;
        }
    }
}
