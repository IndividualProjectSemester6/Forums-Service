using ForumsService.Domain.Entities;

namespace ForumsService.Application.Interfaces.Repositories
{
    public interface IQueryForumRepository
    {
        Task<IEnumerable<ForumDto>> GetAll();
        Task<ForumDto?> Get(Guid id);
    }
}
