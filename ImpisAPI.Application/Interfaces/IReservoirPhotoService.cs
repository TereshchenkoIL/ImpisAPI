using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ImpisAPI.Application.DTOs;
using Microsoft.AspNetCore.Http;

namespace ImpisAPI.Application.Interfaces
{
    public interface IReservoirPhotoService
    {
        Task<PhotoDto> GetById(Guid photoId);
        
        Task<IEnumerable<PhotoDto>> GetAllAsync();

        Task<PhotoDto> CreateAsync(IFormFile file);
       
        Task DeleteAsync(Guid id);
        
        Task SetMainAsync(Guid id);
        Task SetBackgroundAsync(Guid id);
    }
}