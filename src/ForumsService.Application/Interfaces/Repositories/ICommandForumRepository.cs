﻿using ForumsService.Domain.Entities;

namespace ForumsService.Application.Interfaces.Repositories
{
    public interface ICommandForumRepository
    {
        Task<ForumDto> CreateForum(ForumDto forum);
        Task<ForumDto?> DeleteForum(Guid id);
        Task<ForumDto?> UpdateForum(ForumDto forum);
        Task<ForumDto?> AddThreadToForum(ThreadDto thread, Guid forumId);
    }
}