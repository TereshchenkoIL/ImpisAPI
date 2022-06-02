using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImpisAPI.Domain.Entities;
using ImpisAPI.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ImpisAPI.Persistence.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly DataContext _context;

        public SaleRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Sales> GetByIdAsync(Guid id)
        {
            return await _context.Sales.FindAsync(id);
        }

        public async Task<IEnumerable<Sales>> GetAllAsync()
        {
            return await _context.Sales.ToListAsync();
        }

        public async Task<IEnumerable<Sales>> GetAllByReservoirIdAsync(Guid id)
        {
            return await _context.Sales
                .Include(sale => sale.Reservoir)
                .Where(sale => sale.Reservoir.Id == id)
                .ToListAsync();
        }

        public void Create(Sales sales)
        {
            _context.Sales.Add(sales);
        }

        public void Update(Sales sales)
        {
            _context.Entry(sales).State = EntityState.Modified;
        }

        public void Delete(Sales sales)
        {
            sales.IsDeleted = true;
        }
    }
}