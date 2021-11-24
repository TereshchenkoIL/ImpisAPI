using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ImpisAPI.Domain.Entities;

namespace ImpisAPI.Domain.Repositories
{
    public interface ITopicRepository
    {
        Task<IEnumerable<Topic>> GetAllByCreatorIdAsync(string creatorId);
        Task<Topic> GetByIdAsync(Guid topicId);
        Task<IEnumerable<Topic>> GetAllAsync();
        void Create(Topic topic);
        void Update(Topic topic); 
        void Delete(Guid id);
        
        
    }
}