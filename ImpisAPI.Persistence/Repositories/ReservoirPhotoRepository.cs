using System.Collections.Generic;
using System.Threading.Tasks;
using ImpisAPI.Domain.Entities;
using ImpisAPI.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ImpisAPI.Persistence.Repositories
{
    public class ReservoirPhotoRepository : IReservoirPhotoRepository
    {
        private readonly DataContext _context;

        public ReservoirPhotoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ReservoirPhoto> GetByIdAsync(string photoId)
        {
            return await _context.ReservoirPhotos
                .FirstOrDefaultAsync(x => x.Id == photoId);
        }

        public async Task<IEnumerable<ReservoirPhoto>> GetAllAsync()
        {
            return await _context.ReservoirPhotos.ToListAsync();
        }

        public void Create(ReservoirPhoto photo)
        {
            _context.ReservoirPhotos.Add(photo);
        }

        public void Update(ReservoirPhoto photo)
        {
            _context.ReservoirPhotos.Update(photo);
        }

        public void Delete(ReservoirPhoto photo)
        {
            photo.IsDeleted = true;
        }
    }
}