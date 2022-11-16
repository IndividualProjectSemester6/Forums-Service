using ForumsService.Application.Interfaces.Repositories;
using ForumsService.Domain.Entities;
using MediatR;

namespace ForumsService.Application.Commands.DeleteForum
{
    public class DeleteForumHandler : IRequestHandler<DeleteForumCommand, ForumDto>
    {
        private readonly ICommandForumRepository _repository;

        public DeleteForumHandler(ICommandForumRepository repository)
        {
            _repository = repository;
        }

        public async Task<ForumDto> Handle(DeleteForumCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.DeleteForum(request.Id);
            return result;
        }
    }
}
