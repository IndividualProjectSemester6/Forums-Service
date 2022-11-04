using ForumsService.Application.Interfaces.Repositories;
using ForumsService.Domain.Entities;
using MediatR;

namespace ForumsService.Application.Queries.GetAllForums
{
    public class GetAllForumsHandler : IRequestHandler<GetAllForumsQuery, IEnumerable<ForumDto>>
    {
        private readonly IQueryForumRepository _repository;

        public GetAllForumsHandler(IQueryForumRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ForumDto>> Handle(GetAllForumsQuery request, CancellationToken cancellationToken)
        {
            var forumList = await _repository.GetAll();
            return forumList;
        }
    }
}
