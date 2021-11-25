using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ImpisAPI.Domain.Entities;

namespace ImpisAPI.Domain.Repositories
{
    public interface IUserRepository 
    {
        Task<AppUser> GetByUserIdAsync(string userId);
        
        Task<AppUser> GetByUsernameAsync(string username);
        
        Task<IEnumerable<AppUser>> GetAllAsync();

    }
}