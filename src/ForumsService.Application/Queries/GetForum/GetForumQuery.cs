using ForumsService.Domain.Entities;
using MediatR;

namespace ForumsService.Application.Queries.GetForum
{
    public class GetForumQuery : IRequest<ForumDto>
    {
        public Guid Id { get;}

        public GetForumQuery(Guid id)
        {
            Id = id;
        }
    }
}
