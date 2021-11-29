using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ImpisAPI.Application.DTOs;

namespace ImpisAPI.Application.Interfaces
{
    public interface IPeriodService
    {
        Task<IEnumerable<PeriodDto>> GetAllAsync();

        Task<PeriodDto> GetByIdAsync(Guid periodId);

        Task CreateAsync(PeriodDto period);
        
        Task UpdateAsync(PeriodDto period);
        
        Task DeleteAsync(Guid periodId);
    }
}