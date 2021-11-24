using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ImpisAPI.Application.DTOs;
using Microsoft.AspNetCore.Http;

namespace ImpisAPI.Application.Interfaces
{
    public interface IUserPhotoService 
    {
        Task<PhotoDto> GetById(string photoId);
        
        Task<IEnumerable<PhotoDto>> GetAllAsync();

        Task<PhotoDto> CreateAsync(IFormFile file);
       
        Task DeleteAsync(string id);
        
        Task SetMainAsync(Guid id);
    }
}