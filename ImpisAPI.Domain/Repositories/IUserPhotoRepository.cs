using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ImpisAPI.Domain.Entities;

namespace ImpisAPI.Domain.Repositories
{
    public interface IPhotoRepository 
    {
        Task<UserPhoto> GetById(Guid photoId);
        Task<IEnumerable<UserPhoto>> GetAllAsync();
        void Create(UserPhoto entity);
        void Update(UserPhoto entity); 
        void Delete(Guid id);
    }

  
}