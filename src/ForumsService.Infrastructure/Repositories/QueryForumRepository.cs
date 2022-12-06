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
            var result = await _context.Forums.Include(f => f.Threads).ToListAsync();
            return result;
        }

        public async Task<ForumDto?> Get(Guid id)
        {
            var result = await _context.Forums.Where(f => f.Id == id)
                .Include("Threads").FirstOrDefaultAsync();
            return result;
        }
    }
}
