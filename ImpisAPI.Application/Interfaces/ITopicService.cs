using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ImpisAPI.Application.DTOs;

namespace ImpisAPI.Application.Interfaces
{
    public interface ITopicService 
    {
       Task<IEnumerable<TopicDto>> GetAllByCreatorUsernameAsync(string username);
       
        
       
       Task<TopicDto> GetByIdAsync(Guid topicId);
       
       
       Task<IEnumerable<TopicDto>> GetAllAsync();

       Task CreateAsync(TopicDto topicForCreation);
       
       Task DeleteAsync(Guid topicId);
       
       Task UpdateAsync(TopicDto topicForUpdation);
       
    }
}