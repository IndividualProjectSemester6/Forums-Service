using ForumsService.Application.Interfaces.Repositories;
using ForumsService.Domain.Entities;
using MediatR;

namespace ForumsService.Application.Queries.GetForum
{
    public class GetForumHandler : IRequestHandler<GetForumQuery, ForumDto?>
    {
        private readonly IQueryForumRepository _repository;

        public GetForumHandler(IQueryForumRepository repository)
        {
            _repository = repository;
        }

        public async Task<ForumDto?> Handle(GetForumQuery request, CancellationToken cancellationToken)
        {
            return await _repository.Get(request.Id);
        }
    }
}
