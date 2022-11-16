using ForumsService.Domain.Entities;
using MediatR;

namespace ForumsService.Application.Commands.DeleteForum
{
    public class DeleteForumCommand : IRequest<ForumDto>
    {
        public Guid Id { get;}

        public DeleteForumCommand(Guid id)
        {
            Id = id;
        }
    }
}
