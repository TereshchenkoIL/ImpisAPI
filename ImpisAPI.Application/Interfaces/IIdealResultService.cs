using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ImpisAPI.Application.DTOs;
using ImpisAPI.Domain.Entities;

namespace ImpisAPI.Application.Interfaces
{
    public interface IIdealResultService
    {
        Task<IEnumerable<IdealResultDto>> GetAllAsync();
        
        Task<IEnumerable<IdealResultDto>> GetByTypeId(Guid typeId);
        
        Task<IdealResultDto> GetByIdAsync(Guid id);
        
        Task CreateAsync(IdealResultDto result);
        
        Task UpdateAsync(IdealResultDto result);
        
        Task RemoveAsync(Guid resultId);
    }
}