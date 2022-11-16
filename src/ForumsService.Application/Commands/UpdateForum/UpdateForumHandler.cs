using ForumsService.Application.Interfaces.Repositories;
using ForumsService.Domain.Entities;
using MediatR;

namespace ForumsService.Application.Commands.UpdateForum
{
    public class UpdateForumHandler : IRequestHandler<UpdateForumCommand, ForumDto?>
    {
        private readonly ICommandForumRepository _repository;

        public UpdateForumHandler(ICommandForumRepository repository)
        {
            _repository = repository;
        }

        public async Task<ForumDto?> Handle(UpdateForumCommand request, CancellationToken cancellationToken)
        {
            return await _repository.UpdateForum(request.ExistingForum);
        }
    }
}
