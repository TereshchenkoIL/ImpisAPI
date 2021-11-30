using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ImpisAPI.Application.DTOs;

namespace ImpisAPI.Application.Interfaces
{
    public interface ISuggestionService
    {
        Task<IEnumerable<SuggestionDto>> GetAllAsync();
        Task<IEnumerable<SuggestionDto>> GetAllByTypeIdAsync(Guid typeId);
        Task<SuggestionDto> GetByIdAsync(Guid id);
        Task CreateAsync(SuggestionDto suggestionDto);
        Task UpdateAsync(SuggestionDto suggestionDto);
        Task DeleteAsync(Guid suggestionId);
    }
}