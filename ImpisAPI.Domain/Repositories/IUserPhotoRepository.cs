using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ImpisAPI.Domain.Entities;

namespace ImpisAPI.Domain.Repositories
{
    public interface IUserPhotoRepository 
    {
        Task<UserPhoto> GetById(string photoId);
        Task<IEnumerable<UserPhoto>> GetAllAsync();
        void Create(UserPhoto entity);
        void Update(UserPhoto entity); 
        void Delete(UserPhoto entity);
    }

  
}