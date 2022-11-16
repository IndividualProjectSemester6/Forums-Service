using ForumsService.Application.Interfaces.Repositories;
using ForumsService.Domain.Entities;
using MediatR;

namespace ForumsService.Application.Commands.CreateForum
{
    public class CreateForumHandler : IRequestHandler<CreateForumCommand, ForumDto>
    {
        private readonly ICommandForumRepository _repository;

        public CreateForumHandler(ICommandForumRepository repository)
        {
            _repository = repository;
        }

        public async Task<ForumDto> Handle(CreateForumCommand request, CancellationToken cancellationToken)
        {
            var forum = new ForumDto(Guid.NewGuid(), request.Name, request.Description);
            var result = await _repository.CreateForum(forum);
            return result;
        }
    }
}
