using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ImpisAPI.Domain.Entities;

namespace ImpisAPI.Domain.Repositories
{
    public interface ISaleRepository
    {
        Task<Sales> GetByIdAsync(Guid reservoirId);
        Task<IEnumerable<Sales>> GetAllAsync();
        Task<IEnumerable<Sales>> GetAllByReservoirIdAsync(Guid id);
        void Create(Sales sales);
        void Update(Sales sales); 
        void Delete(Sales sales);
    }
}