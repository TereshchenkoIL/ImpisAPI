using System;
using System.Threading.Tasks;
using ImpisAPI.Domain.Entities;

namespace ImpisAPI.Domain.Repositories
{
    public interface IReservoirPhotoRepository
    {
        Task<ReservoirPhotos> GetByIdAsync(Guid id);
        void Create(ReservoirPhotos parameters);
        void Update(ReservoirPhotos parameters); 
        void Delete(Guid id);
    }
}