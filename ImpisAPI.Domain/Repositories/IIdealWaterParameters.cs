using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ImpisAPI.Domain.Entities;

namespace ImpisAPI.Domain.Repositories
{
    public interface IIdealWaterParameters
    {
        Task<IdealWaterParameters> GetByIdAsync(Guid waterParameterId);
        Task<IEnumerable<IdealWaterParameters>> GetAllAsync();
        Task<IEnumerable<IdealWaterParameters>> GetByTypeIdAsync(Guid type);
        void Create(IdealWaterParameters idealWaterParameters);
        void Update(IdealWaterParameters idealWaterParameters); 
        void Delete(IdealWaterParameters idealWaterParameters);
    }
}