using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ImpisAPI.Domain.Entities;
using ImpisAPI.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ImpisAPI.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<AppUser> GetByUserIdAsync(string userId)
        {
            return await _context.Users
                    .Include(p => p.Photos)
                    .Include(t => t.Topics)
                    .FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task<AppUser> GetByUsernameAsync(string username)
        {
            return  await _context.Users
                    .Include(p => p.Photos)
                    .Include(t => t.Topics)
                    .FirstOrDefaultAsync(u => u.UserName == username);
        }

        public async Task<IEnumerable<AppUser>> GetAllAsync()
        {
            return await _context.Users
                .Include(p => p.Photos)
                .Include(t => t.Topics)
                .ToListAsync();
        }
        
    }
}