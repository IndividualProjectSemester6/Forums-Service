﻿using ForumsService.Application.Interfaces.Repositories;
using ForumsService.Domain.Entities;
using ForumsService.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;

namespace ForumsService.Infrastructure.Repositories
{
    public class CommandForumRepository : ICommandForumRepository
    {
        private readonly ForumDbContext _context;

        public CommandForumRepository(ForumDbContext context)
        {
            _context = context;
        }

        public async Task<ForumDto> CreateForum(ForumDto forum)
        {
            await _context.AddAsync(forum); 
            await _context.SaveChangesAsync();

            return forum;
        }

        public async Task<ForumDto?> DeleteForum(Guid id)
        {
            var forum = await _context.Forums.FindAsync(id);
            if (forum == null) return null;
            await Task.WhenAll(_context.Forums.Where(m => m.Id == id).DeleteAsync(), _context.SaveChangesAsync());
            return forum;
        }

        public async Task<ForumDto?> UpdateForum(ForumDto forum)
        {
            var existing = await _context.Forums.FindAsync(forum.Id);
            if (existing == null) return null;
            existing.Name = forum.Name;
            existing.Description = forum.Description;
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<ForumDto?> AddThreadToForum(ThreadDto thread, Guid forumId)
        {
            var existing = await _context.Forums.FindAsync(forumId);
            if (existing == null) return null;
            
            thread.Forum = existing;
            await _context.AddAsync(thread);
            await _context.SaveChangesAsync();
            return existing;
        }
    }
}
