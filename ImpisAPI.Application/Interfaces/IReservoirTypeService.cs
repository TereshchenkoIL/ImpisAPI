using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ImpisAPI.Application.DTOs;

namespace ImpisAPI.Application.Interfaces
{
    public interface IReservoirTypeService
    {
        Task<IEnumerable<ReservoirTypeDto>> GetAllAsync();
        Task<ReservoirTypeDto> GetByIdAsync(Guid id);
        Task CreateAsync(ReservoirDto reservoirDto);
        Task DeleteAsync(Guid reservoirId);
    }
}