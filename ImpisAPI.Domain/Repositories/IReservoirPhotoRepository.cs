using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ImpisAPI.Domain.Entities;

namespace ImpisAPI.Domain.Repositories
{
    public interface IReservoirPhotoRepository
    {
        Task<ReservoirPhoto> GetByIdAsync(string id);
        Task<IEnumerable<ReservoirPhoto>> GetAllAsync();
        void Create(ReservoirPhoto parameters);
        void Update(ReservoirPhoto parameters); 
        void Delete(ReservoirPhoto parameters);
    }
}