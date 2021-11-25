using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ImpisAPI.Domain.Entities;

namespace ImpisAPI.Domain.Repositories
{
    public interface IWaterParametersRepository
    {
        Task<WaterParameters> GetByIdAsync(Guid waterParameterId);
        Task<IEnumerable<WaterParameters>> GetAllAsync();
        Task<IEnumerable<WaterParameters>> GetAllByReservoirIdAsync(Guid reservoirId);
        void Create(WaterParameters parameters);
        void Update(WaterParameters parameters); 
        void Delete(WaterParameters parameters);
    }
}