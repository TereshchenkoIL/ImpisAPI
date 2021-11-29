using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImpisAPI.Domain.Entities;
using ImpisAPI.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ImpisAPI.Persistence.Repositories
{
    public class IdealResultRepository : IIdealResultRepository
    {
        private readonly DataContext _context;

        public IdealResultRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IdealResult> GetByIdAsync(Guid idealResultId)
        {
            var result = await _context.IdealResults
                .Include(result => result.Type)
                .Include(result => result.Period)
                .FirstOrDefaultAsync(x => x.Id == idealResultId);
            return result;
        }

        public async Task<IEnumerable<IdealResult>> GetAllAsync()
        {
            var result = await _context.IdealResults.Include(result => result.Type).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<IdealResult>> GetByTypeIdAsync(Guid type)
        {
            var results = await _context.IdealResults
                .Include(result => result.Type)
                .Include(result => result.Period)
                .Where(x => x.Type.Id == type)
                .ToListAsync();
            return results;
        }

        public void Create(IdealResult idealResult)
        {
            _context.IdealResults.Add(idealResult);
        }

        public void Update(IdealResult idealResult)
        {
            _context.Entry(idealResult).State = EntityState.Modified;
        }

        public void Delete(IdealResult idealResult)
        {
            _context.IdealResults.Remove(idealResult);
        }
    }
}