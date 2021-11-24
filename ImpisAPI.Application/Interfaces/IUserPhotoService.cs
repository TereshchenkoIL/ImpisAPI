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
        Task<PhotoDto> GetById(Guid photoId);
        
        Task<IEnumerable<PhotoDto>> GetAllAsync();

        Task<PhotoDto> CreateAsync(IFormFile file);
       
        Task DeleteAsync(Guid id);
        
        Task SetMainAsync(Guid id);
    }
}