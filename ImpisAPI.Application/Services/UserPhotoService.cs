using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ImpisAPI.Application.DTOs;
using ImpisAPI.Application.Interfaces;
using ImpisAPI.Domain.Entities;
using ImpisAPI.Domain.Interfaces;
using ImpisAPI.Domain.Repositories;
using Microsoft.AspNetCore.Http;

namespace ImpisAPI.Application.Services
{
    public class UserPhotoService : IUserPhotoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserAccessor _userAccessor;
        private readonly IPhotoAccessor _photoAccessor;
        private readonly IUserPhotoRepository _photoRepository;
        private readonly IUserRepository _userRepository;

        public UserPhotoService(IUnitOfWork unitOfWork, IMapper mapper, IUserAccessor userAccessor, IPhotoAccessor photoAccessor, IUserPhotoRepository photoRepository, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userAccessor = userAccessor;
            _photoAccessor = photoAccessor;
            _photoRepository = photoRepository;
            _userRepository = userRepository;
        }
        public async Task<PhotoDto> GetById(string photoId)
        {
            var photo = await _photoRepository.GetById(photoId);
            

            return _mapper.Map<PhotoDto>(photo);

        }

        public async Task<IEnumerable<PhotoDto>> GetAllAsync()
        {
            var photos = await _photoRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<PhotoDto>>(photos);
        }

        public async  Task<PhotoDto> CreateAsync(IFormFile file)
        {
            var username = _userAccessor.GetUsername();

            var user = await _userRepository.GetByUsernameAsync(username);
         
            
            var photoResult = await _photoAccessor.AddPhoto(file);

            var photoForCreation = new UserPhoto
            {
                Id = photoResult.PublicId,
                Url = photoResult.Url
            };

            user.Photos.Add(photoForCreation);
            var result = await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<PhotoDto>(photoForCreation);
            
        }

        public async Task DeleteAsync(string id)
        {
            var photo = await _photoRepository.GetById(id);
            _photoRepository.Delete(photo);

            var result = await _unitOfWork.SaveChangesAsync();

            var cloudinaryResult = await _photoAccessor.DeletePhoto(id);

        }

        public async Task SetMainAsync(Guid id)
        {
            var user = await _userRepository.GetByUsernameAsync(_userAccessor.GetUsername());

            if (user != null) user.Photos.FirstOrDefault(p => p.IsMain).IsMain = false;
        }
    }
}