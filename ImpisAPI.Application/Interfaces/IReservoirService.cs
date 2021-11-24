using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ImpisAPI.Application.DTOs;
using ImpisAPI.Domain.Entities;

namespace ImpisAPI.Application.Interfaces
{
    public interface IReservoirRepository
    {
        Task<IEnumerable<ReservoirDto>> GetAllAsync();
        Task<IEnumerable<ReservoirDto>> GetAllByUserIdAsync(string userId);

        Task CreateAsync(ReservoirDto topicForCreation);
       
        Task DeleteAsync(Guid reservoirId);
        
    }
}