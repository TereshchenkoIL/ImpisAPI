using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ImpisAPI.Domain.Entities;

namespace ImpisAPI.Domain.Repositories
{
    public interface IWaterParametersRepository
    {
        Task<Reservoir> GetByIdAsync(Guid waterParameterId);
        Task<IEnumerable<WaterParameters>> GetAllAsync();
        void Create(WaterParameters parameters);
        void Update(WaterParameters parameters); 
        void Delete(Guid id);
    }
}