using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ImpisAPI.Domain.Entities;

namespace ImpisAPI.Domain.Repositories
{
    public interface IReservoirPhotoRepository
    {
        Task<ReservoirPhotos> GetByIdAsync(string id);
        Task<IEnumerable<ReservoirPhotos>> GetAllAsync();
        void Create(ReservoirPhotos parameters);
        void Update(ReservoirPhotos parameters); 
        void Delete(string id);
    }
}