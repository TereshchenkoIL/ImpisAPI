using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using ImpisAPI.Application.DTOs;
using ImpisAPI.Application.Interfaces;
using ImpisAPI.Domain.Entities;
using ImpisAPI.Domain.Repositories;

namespace ImpisAPI.Application.Services
{
    public class ReservoirService : IReservoirService
    {
        private readonly IReservoirRepository _reservoirRepository;
        private readonly IReservoirTypeRepository _typeRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ReservoirService( IMapper mapper, IReservoirTypeRepository typeRepository, IReservoirRepository reservoirRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _typeRepository = typeRepository;
            _reservoirRepository = reservoirRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ReservoirDto>> GetAllAsync()
        {
            var reservoirs = await _reservoirRepository.GetAllAsync();
            var reservoirsDto = _mapper.Map<IEnumerable<ReservoirDto>>(reservoirs);
            return reservoirsDto;
        }

        public async Task<IEnumerable<ReservoirDto>> GetAllByUserIdAsync(string userId)
        {
            var reservoirs = await _reservoirRepository.GetAllByUserIdAsync(userId);
            var reservoirsDto = _mapper.Map<IEnumerable<ReservoirDto>>(reservoirs);
            return reservoirsDto;
        }

        public async Task<ReservoirDto> GetByIdAsync(Guid id)
        {
            var reservoir = await _reservoirRepository.GetByIdAsync(id);
            var reservoirDto = _mapper.Map<ReservoirDto>(reservoir);
            return reservoirDto;
        }

        public async Task CreateAsync(ReservoirDto reservoirForCreation)
        {
            var reservoir = _mapper.Map<Reservoir>(reservoirForCreation);
            await _reservoirRepository.CreateAsync(reservoir);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid reservoirId)
        {
            var reservoir = await _reservoirRepository.GetByIdAsync(reservoirId);
            _reservoirRepository.Delete(reservoir);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}