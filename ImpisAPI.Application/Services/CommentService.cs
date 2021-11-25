using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ImpisAPI.Application.DTOs;
using ImpisAPI.Application.Interfaces;
using ImpisAPI.Domain.Entities;
using ImpisAPI.Domain.Repositories;

namespace ImpisAPI.Application.Services
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICommentRepository _commentRepository;
        private readonly ITopicRepository _topicRepository;
        public readonly IUserRepository _userRepository;
        public CommentService(IUnitOfWork unitOfWork, IMapper mapper, ICommentRepository commentRepository, ITopicRepository topicRepository, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _commentRepository = commentRepository;
            _topicRepository = topicRepository;
            _userRepository = userRepository;
        }
        public async Task<CommentDto> GetByIdAsync(Guid commentId)
        {
            var comment = await _commentRepository.GetByIdAsync(commentId);
            
            return _mapper.Map<CommentDto>(comment);
        }

        public async Task<IEnumerable<CommentDto>> GetAllAsync()
        {
            var comments = await _commentRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<CommentDto>>(comments);
        }

        public async Task<IEnumerable<CommentDto>> GetAllByTopicAsync(Guid topicId)
        {
            var topic = await _topicRepository.GetByIdAsync(topicId);

            var comments = await _commentRepository.GetAllByTopicAsync(topicId);

            return _mapper.Map<IEnumerable<CommentDto>>(comments);
        }

        public async Task<CommentDto> CreateAsync(CommentCreateDto commentForCreation)
        {
            var comment = _mapper.Map<Comment>(commentForCreation);

            

            var user = await _userRepository.GetByUsernameAsync(commentForCreation.Username);
           
            var topic = await _topicRepository.GetByIdAsync(commentForCreation.TopicId);
             comment.Author = user;
             comment.Topic = topic;
            _commentRepository.Create(comment);

            var result = await  _unitOfWork.SaveChangesAsync();

            return _mapper.Map<CommentDto>(comment);
        }

        public async Task DeleteAsync(Guid commentId)
        {
            var comment = await _commentRepository.GetByIdAsync(commentId);
            _commentRepository.Delete(comment);

            var result = await  _unitOfWork.SaveChangesAsync();
            
        }

        public async Task UpdateAsync(CommentUpdateDto commentForUpdation)
        {
            var comment = await _commentRepository.GetByIdAsync(commentForUpdation.Id);
            

            _mapper.Map(commentForUpdation, comment);

            var result = await _unitOfWork.SaveChangesAsync();
            
        }
    }
}