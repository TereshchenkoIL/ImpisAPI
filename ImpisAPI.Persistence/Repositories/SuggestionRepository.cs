using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImpisAPI.Domain.Entities;
using ImpisAPI.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ImpisAPI.Persistence.Repositories
{
    public class SuggestionRepository : ISuggestionRepository
    {
        private readonly DataContext _context;

        public SuggestionRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Suggestion> GetByIdAsync(Guid id)
        {
            return await _context.Suggestions.FindAsync(id);
        }

        public async Task<IEnumerable<Suggestion>> GetAllAsync()
        {
            return await _context.Suggestions.ToListAsync();
        }

        public async Task<IEnumerable<Suggestion>> GetAllByTypeIdAsync(Guid typeId)
        {
            return await _context.Suggestions
                .Include(s => s.Type)
                .Where(s => s.Type.Id == typeId)
                .ToListAsync();
        }

        public void Create(Suggestion suggestion)
        {
            _context.Add(suggestion);
        }

        public void Update(Suggestion suggestion)
        {
            _context.Update(suggestion);
        }

        public void Delete(Suggestion suggestion)
        {
            suggestion.IsDeleted = true;
        }
    }
}