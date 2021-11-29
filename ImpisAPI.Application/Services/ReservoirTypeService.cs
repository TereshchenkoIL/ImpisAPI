using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ImpisAPI.Application.DTOs;
using ImpisAPI.Application.Interfaces;
using ImpisAPI.Domain.Entities;
using ImpisAPI.Domain.Repositories;

namespace ImpisAPI.Application.Services
{
    public class ReservoirTypeService : IReservoirTypeService
    {
        private readonly IReservoirTypeRepository _reservoirTypeRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ReservoirTypeService(IReservoirTypeRepository reservoirTypeRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _reservoirTypeRepository = reservoirTypeRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ReservoirTypeDto>> GetAllAsync()
        {
            var types = await _reservoirTypeRepository.GetAllAsync();

            var typeDtos = _mapper.Map<IEnumerable<ReservoirTypeDto>>(types);

            return typeDtos;
        }

        public async Task<ReservoirTypeDto> GetByIdAsync(Guid id)
        {
            var type = await _reservoirTypeRepository.GetByIdAsync(id);

            var typeDto = _mapper.Map<ReservoirTypeDto>(type);

            return typeDto;
        }

        public async Task CreateAsync(ReservoirTypeDto reservoirTypeDto)
        {
            var type = _mapper.Map<ReservoirType>(reservoirTypeDto);
            
            _reservoirTypeRepository.Create(type);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(ReservoirTypeDto reservoirTypeDto)
        {
            var type = _mapper.Map<ReservoirType>(reservoirTypeDto);
            
            _reservoirTypeRepository.Update(type);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid reservoirId)
        {
            var type = await _reservoirTypeRepository.GetByIdAsync(reservoirId);
            
            _reservoirTypeRepository.Delete(type);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}