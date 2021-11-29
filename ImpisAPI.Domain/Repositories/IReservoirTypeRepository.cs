using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ImpisAPI.Domain.Entities;

namespace ImpisAPI.Domain.Repositories
{
    public interface IReservoirTypeRepository
    {
        Task<IEnumerable<ReservoirType>> GetAllAsync();
        Task<ReservoirType> GetByIdAsync(Guid id);

        void Create(ReservoirType reservoirType);
        void Update(ReservoirType reservoirType);
        void Delete(ReservoirType reservoirType);
    }
}