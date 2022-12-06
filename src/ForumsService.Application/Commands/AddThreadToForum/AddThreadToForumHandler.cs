using ForumsService.Application.Interfaces.Repositories;
using ForumsService.Domain.Entities;
using MediatR;

namespace ForumsService.Application.Commands.AddThreadToForum
{
    public class AddThreadToForumHandler : IRequestHandler<AddThreadToForumCommand, ForumDto>
    {
        private readonly ICommandForumRepository _repository;

        public AddThreadToForumHandler(ICommandForumRepository repository)
        {
            _repository = repository;
        }

        public async Task<ForumDto> Handle(AddThreadToForumCommand request, CancellationToken cancellationToken)
        {
           var forum = await _repository.AddThreadToForum(request.Thread, request.ForumId);
           return forum;
        }
    }
}
