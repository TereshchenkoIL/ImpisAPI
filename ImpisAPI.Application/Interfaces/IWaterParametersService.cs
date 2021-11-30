using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ImpisAPI.Application.DTOs;

namespace ImpisAPI.Application.Interfaces
{
    public interface IWaterParametersService
    {
        Task<IEnumerable<WaterParametersDto>> GetAllAsync();
        Task<IEnumerable<WaterParametersDto>> GetAllByReservoirIdAsync(Guid reservoirId);
        Task<WaterParametersDto> GetByIdAsync(Guid id);
        Task CreateAsync(WaterParametersDto waterParameters);
        Task DeleteAsync(Guid parametersId);
    }
}