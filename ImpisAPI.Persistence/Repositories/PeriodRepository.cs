using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ImpisAPI.Domain.Entities;
using ImpisAPI.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ImpisAPI.Persistence.Repositories
{
    public class PeriodRepository : IPeriodRepository
    {
        private readonly DataContext _context;

        public PeriodRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Period>> GetAllAsync()
        {
            var periods = await _context.Periods.ToListAsync();
            return periods;
        }
        public async Task<Period> GetByIdAsync(Guid periodId)
        {
            var periods = await _context.Periods.FindAsync(periodId);
            return periods;
        }

        public void Create(Period period)
        {
            _context.Periods.Add(period);
        }

        public void Update(Period period)
        {
            _context.Entry(period).State = EntityState.Modified;
        }

        public void Delete(Period period)
        {
            _context.Periods.Remove(period);
        }
    }
}