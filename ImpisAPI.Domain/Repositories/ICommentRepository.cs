using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ImpisAPI.Domain.Entities;

namespace ImpisAPI.Domain.Repositories
{
    public interface ICommentRepository 
    {
        Task<Comment> GetByIdAsync(Guid commentId);
        Task<IEnumerable<Comment>> GetAllByTopicAsync(Guid topicId);
        Task<IEnumerable<Comment>> GetAllAsync();
        void Create(Comment comment);
        void Update(Comment comment); 
        void Delete(Comment comment);
    }
}