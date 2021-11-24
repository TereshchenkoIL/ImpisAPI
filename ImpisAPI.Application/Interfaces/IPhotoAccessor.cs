using System;
using System.Threading.Tasks;
using ImpisAPI.Application.DTOs;
using Microsoft.AspNetCore.Http;

namespace ImpisAPI.Application.Interfaces
{
    public interface IPhotoAccessor
    {
        Task<PhotoUploadDto> AddPhoto(IFormFile file);
        Task<string> DeletePhoto(string publicId);
    }
}