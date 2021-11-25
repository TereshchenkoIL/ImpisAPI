using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.Interfaces;
using ImpisAPI.Application.DTOs;
using ImpisAPI.Application.Interfaces;
using ImpisAPI.Domain.Entities;
using ImpisAPI.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using IReservoirRepository = ImpisAPI.Domain.Repositories.IReservoirRepository;

namespace ImpisAPI.Application.Services
{
    public class ReservoirPhotoService : IReservoirPhotoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserAccessor _userAccessor;
        private readonly IPhotoAccessor _photoAccessor;
        private readonly IReservoirPhotoRepository _photoRepository;
        private readonly IUserRepository _userRepository;
        private readonly IReservoirRepository _reservoirRepository;

        public ReservoirPhotoService(IUnitOfWork unitOfWork, IMapper mapper, IUserAccessor userAccessor, IPhotoAccessor photoAccessor, IUserRepository userRepository, IReservoirPhotoRepository photoRepository, IReservoirRepository reservoirRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userAccessor = userAccessor;
            _photoAccessor = photoAccessor;
            _userRepository = userRepository;
            _photoRepository = photoRepository;
            _reservoirRepository = reservoirRepository;
        }
        public async Task<PhotoDto> GetById(string photoId)
        {
            var photo = await _photoRepository.GetByIdAsync(photoId);
            

            return _mapper.Map<PhotoDto>(photo);

        }

        public async Task<IEnumerable<PhotoDto>> GetAllAsync()
        {
            var photos = await _photoRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<PhotoDto>>(photos);
        }

        public async  Task<PhotoDto> CreateAsync(IFormFile file, Guid reservoirId)
        {
            var reservoir = await _reservoirRepository.GetByIdAsync(reservoirId);
         
            
            var photoResult = await _photoAccessor.AddPhoto(file);

            var photoForCreation = new ReservoirPhoto()
            {
                Id = photoResult.PublicId,
                Url = photoResult.Url
            };

            reservoir.Photos.Add(photoForCreation);
            var result = await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<PhotoDto>(photoForCreation);
            
        }

        public async Task DeleteAsync(string id)
        {
            var photo = await _photoRepository.GetByIdAsync(id);
            _photoRepository.Delete(photo);
            var result = await _unitOfWork.SaveChangesAsync();

            
            var cloudinaryResult = await _photoAccessor.DeletePhoto(id);

        }

        public async Task SetMainAsync(string id, Guid reservoirId)
        {
            var reservoir = await _reservoirRepository.GetByIdAsync(reservoirId);
            var photo = await _photoRepository.GetByIdAsync(id);
            photo.IsMain = true;

            if (reservoir!= null) reservoir.Photos.FirstOrDefault(p => p.IsMain).IsMain = false;
        }

        public async Task SetBackgroundAsync(string id, Guid reservoirId)
        {
            var reservoir = await _reservoirRepository.GetByIdAsync(reservoirId);
            var photo = await _photoRepository.GetByIdAsync(id);
            photo.IsBackground = true;

            if (reservoir!= null) reservoir.Photos.FirstOrDefault(p => p.IsMain).IsBackground = false;
        }
    }
}