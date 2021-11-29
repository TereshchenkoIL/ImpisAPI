using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ImpisAPI.Domain.Entities;
using ImpisAPI.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ImpisAPI.Persistence.Repositories
{
    public class ReservoirTypeRepository : IReservoirTypeRepository
    {
        private readonly DataContext _context;

        public ReservoirTypeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ReservoirType>> GetAllAsync()
        {
            var types = await _context.ReservoirTypes.ToListAsync();
            return types;
        }

        public async Task<ReservoirType> GetByIdAsync(Guid id)
        {
            var type = await _context.ReservoirTypes.FindAsync(id);

            return type;
        }
        

        public void Create(ReservoirType reservoirType)
        {
            _context.ReservoirTypes.Add(reservoirType);
        }

        public void Update(ReservoirType reservoirType)
        {
            _context.Entry(reservoirType).State = EntityState.Modified;
        }

        public void Delete(ReservoirType reservoirType)
        {
            _context.ReservoirTypes.Remove(reservoirType);
        }
    }
}