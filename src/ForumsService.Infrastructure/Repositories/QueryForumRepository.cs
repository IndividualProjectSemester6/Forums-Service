using ForumsService.Application.Interfaces.Repositories;
using ForumsService.Domain.Entities;
using ForumsService.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ForumsService.Infrastructure.Repositories
{
    public class QueryForumRepository : IQueryForumRepository
    {
        private readonly ForumDbContext _context;

        public QueryForumRepository(ForumDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ForumDto>> GetAll()
        {
            return await _context.Forums.ToListAsync();
        }

        public async Task<ForumDto?> Get(Guid id)
        {
            return await _context.Forums.FindAsync(id);
        }
    }
}
