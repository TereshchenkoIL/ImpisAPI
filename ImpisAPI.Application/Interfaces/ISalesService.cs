using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ImpisAPI.Application.DTOs;

namespace ImpisAPI.Application.Interfaces
{
    public interface ISalesService
    {
        Task<IEnumerable<SalesDto>> GetAllAsync();
        Task<IEnumerable<SalesDto>> GetAllByReservoirIdAsync(Guid reservoirId);
        Task<SalesDto> GetByIdAsync(Guid id);
        Task CreateAsync(SalesDto salesDto);
        Task DeleteAsync(Guid salesId);
    }
}