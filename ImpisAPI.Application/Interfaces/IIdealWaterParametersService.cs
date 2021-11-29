using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ImpisAPI.Application.DTOs;
using ImpisAPI.Domain.Entities;

namespace ImpisAPI.Application.Interfaces
{
    public interface IIdealWaterParametersService
    {
        Task<IEnumerable<IdealWaterParametersDto>> GetAllAsync();

        Task<IEnumerable<IdealWaterParametersDto>> GetByTypeId(Guid typeId);
        Task<IdealWaterParametersDto> GetByIdAsync(Guid parameterId);

        Task CreateAsync(IdealWaterParametersDto parameters);
        
        Task UpdateAsync(IdealWaterParametersDto parameters);
        
        Task DeleteAsync(Guid parameterId);
    }
}