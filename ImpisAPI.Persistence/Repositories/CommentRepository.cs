using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImpisAPI.Domain.Entities;
using ImpisAPI.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ImpisAPI.Persistence.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly DataContext _context;
        public CommentRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Comment> GetByIdAsync(Guid commentId)
        {
            return await _context.Comments
                    .Include(x => x.Author)
                    .ThenInclude(p => p.Photos)
                    .Include(t => t.Topic)
                    .FirstOrDefaultAsync(x => x.Id == commentId);
        }

        public async Task<IEnumerable<Comment>> GetAllByTopicAsync(Guid topicId)
        {
            return await _context.Comments
                    .Include(x => x.Author)
                    .ThenInclude(p => p.Photos)
                    .Include(t => t.Topic)
                    .Where(x => x.Topic.Id == topicId)
                    .ToListAsync();
        }

        public async Task<IEnumerable<Comment>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public void Create(Comment comment)
        {
            _context.Comments.Add(comment);
        }

        public void Update(Comment comment)
        {
            _context.Comments.Update(comment);
        }

        public void Delete(Comment comment)
        {
            comment.IsDeleted = true;
        }
    }
}