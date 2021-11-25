using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ImpisAPI.Domain.Entities;
using ImpisAPI.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ImpisAPI.Persistence.Repositories
{
    public class UserPhotoRepository : IUserPhotoRepository
    {
        private readonly DataContext _context;

        public UserPhotoRepository(DataContext context)
        {
            _context = context;
        }

        

        public async Task<UserPhoto> GetById(string photoId)
        {
            return await _context.UserPhotos
                .FirstOrDefaultAsync(x => x.Id == photoId);
        }

        public Task<IEnumerable<UserPhoto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public void Create(UserPhoto entity)
        {
            _context.UserPhotos.Add(entity);
        }

        public void Update(UserPhoto entity)
        {
            _context.UserPhotos.Update(entity);
        }

        public void Delete(UserPhoto entity)
        {
            entity.IsDeleted = true;
        }
    }
}