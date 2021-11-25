using System.Threading;
using System.Threading.Tasks;
using ImpisAPI.Domain.Repositories;

namespace ImpisAPI.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
    
        
        public UnitOfWork(DataContext context)
        {
            _context = context;
        }
      
        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}