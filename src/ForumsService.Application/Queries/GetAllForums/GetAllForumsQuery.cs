using ForumsService.Domain.Entities;
using MediatR;

namespace ForumsService.Application.Queries.GetAllForums
{
    public class GetAllForumsQuery : IRequest<IEnumerable<ForumDto>>
    {
    }
}
