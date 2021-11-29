using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImpisAPI.Domain.Entities;
using ImpisAPI.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ImpisAPI.Persistence.Repositories
{
    public class IdealWaterParametersRepository : IIdealWaterParametersRepository
    {
        private readonly DataContext _context;

        public IdealWaterParametersRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IdealWaterParameters> GetByIdAsync(Guid waterParameterId)
        {
            var idealParameter = await _context.IdealWaterParameters
                .Include(parameters => parameters.Type)
                .Include(parameters => parameters.Period)
                .FirstOrDefaultAsync(parameters => parameters.Id == waterParameterId);
            return idealParameter;
        }

        public async Task<IEnumerable<IdealWaterParameters>> GetAllAsync()
        {
            var idealParameters = await _context.IdealWaterParameters
                .Include(parameters => parameters.Type)
                .Include(parameters => parameters.Period)
                .ToListAsync();
            return idealParameters;
        }

        public async Task<IEnumerable<IdealWaterParameters>> GetByTypeIdAsync(Guid type)
        {
            var idealParameters = await _context.IdealWaterParameters
                .Include(parameters => parameters.Type)
                .Include(parameters => parameters.Period)
                .Where(parameters => parameters.Type.Id == type )
                .ToListAsync();
            return idealParameters;
        }

        public async void Create(IdealWaterParameters idealWaterParameters)
        {
            var type = await _context.ReservoirTypes.FindAsync(idealWaterParameters.Id);

            idealWaterParameters.Type = type;

            _context.IdealWaterParameters.Add(idealWaterParameters);
        }

        public void Update(IdealWaterParameters idealWaterParameters)
        {
            _context.Entry(idealWaterParameters).State = EntityState.Modified;
        }

        public void Delete(IdealWaterParameters idealWaterParameters)
        {
            _context.IdealWaterParameters.Remove(idealWaterParameters);
        }
    }
}