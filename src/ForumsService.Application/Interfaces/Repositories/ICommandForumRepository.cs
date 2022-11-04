using ForumsService.Domain.Entities;

namespace ForumsService.Application.Interfaces.Repositories
{
    public interface ICommandForumRepository
    {
        Task<ForumDto> CreateForum(ForumDto forum);
        Task<ForumDto?> DeleteForum(ForumDto forum);
        Task<ForumDto?> UpdateForum(ForumDto forum);
    }
}