using System;
using System.Threading.Tasks;
using ImpisAPI.Domain.Entities;

namespace ImpisAPI.Domain.Repositories
{
    public interface IReservoirTypeRepository
    {
        Task<ReservoirType> GetByIdAsync(Guid id);
    }
}