using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ImpisAPI.Domain.Entities;

namespace ImpisAPI.Domain.Repositories
{
    public interface IReservoirRepository
    {
        Task<Reservoir> GetByIdAsync(Guid reservoirId);
        Task<IEnumerable<Reservoir>> GetAllAsync();
        Task<IEnumerable<Reservoir>> GetAllByUserIdAsync(string id);
        void Create(Reservoir topic);
        void Update(Reservoir topic); 
        void Delete(Guid id);
    }
}