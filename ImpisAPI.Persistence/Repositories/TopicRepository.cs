using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ImpisAPI.Domain.Entities;
using ImpisAPI.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ImpisAPI.Persistence.Repositories
{
    public class TopicRepository : ITopicRepository
    {
        private readonly DataContext _context;

        public TopicRepository(DataContext context)
        {
            _context = context;
        }

        public  async Task<IEnumerable<Topic>> GetByConditionAsync(Expression<Func<Topic, bool>> expression)
        {
            return await _context.Topics
                    .Include(x => x.Creator)
                    .ThenInclude(x => x.Topics)
                    .Include(x => x.Creator)
                    .ThenInclude(x => x.Photos)
                    .Where(expression)
                    .OrderByDescending(x => x.CreatedAt)
                    .ToListAsync();
        }

        public async Task<IEnumerable<Topic>> GetAllAsync()
        {
            return  await _context.Topics
                    .Include(x => x.Creator)
                    .ThenInclude(x => x.Topics)
                    .Include(x => x.Creator)
                    .ThenInclude(x => x.Photos)
                    .OrderByDescending(x => x.CreatedAt)
                    .ToListAsync();
        }

        public void Create(Topic topic)
        {
            _context.Topics.Add(topic);
        }

        public void Update(Topic topic)
        {
            _context.Topics.Update(topic);
        }

        public void Delete(Topic topic)
        {
            topic.IsDeleted = true;
        }

        public async Task<IEnumerable<Topic>> GetAllByCreatorIdAsync(string creatorId)
        {
            return await GetByConditionAsync(x => x.Creator.Id == creatorId);
        }

        
        public async Task<Topic> GetByIdAsync(Guid topicId)
        {
            return  await _context.Topics
                    .Include(x => x.Creator)
                    .ThenInclude(x => x.Topics)
                    .Include(x => x.Creator)
                    .ThenInclude(x => x.Photos)
                    .FirstOrDefaultAsync(x => x.Id == topicId);
        }
    }
}