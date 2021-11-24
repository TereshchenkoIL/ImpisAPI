using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ImpisAPI.Domain.Entities;

namespace ImpisAPI.Domain.Repositories
{
    public interface ISuggestionRepository
    {
        Task<Suggestion> GetByIdAsync(Guid waterParameterId);
        Task<IEnumerable<Suggestion>> GetAllAsync();
        void Create(Suggestion suggestion);
        void Update(Suggestion suggestion); 
        void Delete(Guid id);
    }
}