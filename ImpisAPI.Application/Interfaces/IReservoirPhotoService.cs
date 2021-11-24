using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ImpisAPI.Application.DTOs;
using Microsoft.AspNetCore.Http;

namespace ImpisAPI.Application.Interfaces
{
    public interface IReservoirPhotoService
    {
        Task<PhotoDto> GetById(string photoId);
        
        Task<IEnumerable<PhotoDto>> GetAllAsync();

        Task<PhotoDto> CreateAsync(IFormFile file, Guid reservoirId);
       
        Task DeleteAsync(string id);
        
        Task SetMainAsync(string id, Guid reservoirId);
        Task SetBackgroundAsync(string id, Guid reservoirId);
    }
}