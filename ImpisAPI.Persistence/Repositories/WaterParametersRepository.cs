using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImpisAPI.Domain.Entities;
using ImpisAPI.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ImpisAPI.Persistence.Repositories
{
    public class WaterParametersRepository : IWaterParametersRepository
    {
        private readonly DataContext _context;

        public WaterParametersRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<WaterParameters> GetByIdAsync(Guid waterParameterId)
        {
            return await _context.WaterParameters.FindAsync(waterParameterId);
        }

        public async Task<IEnumerable<WaterParameters>> GetAllAsync()
        {
            return await _context.WaterParameters.ToListAsync();
        }

        public async Task<IEnumerable<WaterParameters>> GetAllByReservoirIdAsync(Guid reservoirId)
        {
            return await _context.WaterParameters
                .Include(w => w.Reservoir)
                .Where(w => w.Reservoir.Id == reservoirId)
                .ToListAsync();
        }

        public void Create(WaterParameters parameters)
        {
            _context.WaterParameters.Add(parameters);
        }

        public void Update(WaterParameters parameters)
        {
            _context.WaterParameters.Update(parameters);
        }

        public void Delete(WaterParameters parameters)
        {
            parameters.IsDeleted = true;
        }
    }
}