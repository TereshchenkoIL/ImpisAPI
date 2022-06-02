using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImpisAPI.Domain.Entities;
using ImpisAPI.Domain.Interfaces;
using ImpisAPI.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ImpisAPI.Persistence.Repositories
{
    public class ReservoirRepository : IReservoirRepository
    {
        private readonly DataContext _context;
        public readonly IUserAccessor _userAccessor;

        public ReservoirRepository(DataContext context, IUserAccessor userAccessor)
        {
            _context = context;
            _userAccessor = userAccessor;
        }

        public async Task<Reservoir> GetByIdAsync(Guid reservoirId)
        {
            return await _context.Reservoirs
                .Include(r => r.Photos)
                .Include(r => r.WaterParameters)
                .Include(r => r.Owner)
                .Include(r => r.Sales)
                .Include(r => r.Type)
                .ThenInclude(t => t.IdealWaterParameters)
                .FirstOrDefaultAsync(r => r.Id == reservoirId);
        }

        public async Task<IEnumerable<Reservoir>> GetAllAsync()
        {
            return await _context.Reservoirs
                .Include(r => r.Photos)
                .Include(r => r.WaterParameters)
                .Include(r => r.Owner)
                .Include(r => r.Sales)
                .Include(r => r.Type)
                .ToListAsync();
        }

        public async Task<IEnumerable<Reservoir>> GetAllByUserIdAsync(string id)
        {
            return await _context.Reservoirs
                .Include(r => r.Photos)
                .Include(r => r.WaterParameters)
                .Include(r => r.Owner)
                .Include(r => r.Sales)
                .Include(r => r.Type)
                .Where(r => r.Owner.Id == id)
                .ToListAsync();
        }

        public async Task CreateAsync(Reservoir reservoir)
        {
            var type = await _context.ReservoirTypes.FindAsync(reservoir.Type.Id);
            reservoir.Type = type;
            var user = await _context.Users.FirstOrDefaultAsync(user => user.UserName == _userAccessor.GetUsername());
            reservoir.Owner = user;
            _context.Reservoirs.Add(reservoir);
        }

        public void Update(Reservoir reservoir)
        {
            _context.Reservoirs.Update(reservoir);
        }

        public void Delete(Reservoir reservoir)
        {
            reservoir.IsDeleted = true;
        }
    }
}