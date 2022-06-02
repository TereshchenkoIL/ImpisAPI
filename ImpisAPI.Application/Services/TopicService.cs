using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ImpisAPI.Application.DTOs;
using ImpisAPI.Application.Interfaces;
using ImpisAPI.Domain.Entities;
using ImpisAPI.Domain.Interfaces;
using ImpisAPI.Domain.Repositories;

namespace ImpisAPI.Application.Services
{
    public class TopicService : ITopicService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserAccessor _userAccessor;
        private readonly IUserRepository _userRepository;
        private readonly ITopicRepository _topicRepository;
        
        public TopicService(IUnitOfWork unitOfWork, IMapper mapper, IUserAccessor userAccessor, IUserRepository userRepository, ITopicRepository topicRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userAccessor = userAccessor;
            _userRepository = userRepository;
            _topicRepository = topicRepository;
        }

        public async Task<IEnumerable<TopicDto>>  GetAllByCreatorUsernameAsync(string username)
        {
            var creator = await _userRepository.GetByUsernameAsync(username);
            
            var topics = await _topicRepository.GetAllByCreatorIdAsync(creator.Id);
            
            var topicsDto =_mapper.Map<IEnumerable<TopicDto>>(topics);
            
            return topicsDto;
        }

      
       

        public async Task<TopicDto> GetByIdAsync(Guid topicId)
        {
            var topic = await _topicRepository.GetByIdAsync(topicId);
            var topicDto = _mapper.Map<TopicDto>(topic);
            return topicDto;
        }


        public async Task<IEnumerable<TopicDto>> GetAllAsync()
        {
            var topics = await _topicRepository.GetAllAsync();
            
            var topicsDto = _mapper.Map<IEnumerable<TopicDto>>(topics);
            return topicsDto;
        }

        public async Task CreateAsync(TopicDto topicForCreation)
        {
            var user = await _userRepository.GetByUsernameAsync(_userAccessor.GetUsername());

            var topic = _mapper.Map<Topic>(topicForCreation);
            topic.Creator = user;
            topic.CreatedAt = DateTime.UtcNow;
            _topicRepository.Create(topic);

           var result = await _unitOfWork.SaveChangesAsync();

        }

        public async Task DeleteAsync(Guid topicId)
        {
            var topic = await _topicRepository.GetByIdAsync(topicId);
            _topicRepository.Delete(topic);

            var result = await _unitOfWork.SaveChangesAsync();

        }

        public async Task UpdateAsync(TopicDto topicForUpdation)
        {
            var topic = await _topicRepository.GetByIdAsync(topicForUpdation.Id);
            topic.Body = topicForUpdation.Body;
            topic.Title = topicForUpdation.Title;

            var result = await _unitOfWork.SaveChangesAsync();
        }
    }
}