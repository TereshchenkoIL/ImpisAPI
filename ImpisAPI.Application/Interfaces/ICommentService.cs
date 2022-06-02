using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentResults;
using ImpisAPI.Application.DTOs;

namespace ImpisAPI.Application.Interfaces
{
    public interface ICommentService
    {
        Task<CommentDto> GetByIdAsync(Guid commentId);
    
       Task<IEnumerable<CommentDto>> GetAllAsync();
       Task<IEnumerable<CommentDto>> GetAllByTopicAsync(Guid topicId);

       Task<CommentDto> CreateAsync(CommentCreateDto commentForCreation);
       
       Task DeleteAsync(Guid commentId);
       
       Task UpdateAsync(CommentUpdateDto commentForUpdate);
    }
}