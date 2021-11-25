using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ImpisAPI.Domain.Entities;

namespace ImpisAPI.Domain.Repositories
{
    public interface IIdealResultRepository
    {
        Task<IdealResult> GetByIdAsync(Guid waterParameterId);
        Task<IEnumerable<IdealResult>> GetAllAsync();
        Task<IEnumerable<IdealResult>> GetByTypeIdAsync(Guid type);
        void Create(IdealResult idealResult);
        void Update(IdealResult idealResult); 
        void Delete(IdealResult idealResult);
    }
}