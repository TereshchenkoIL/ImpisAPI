using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FluentResults;
using ImpisAPI.Application.DTOs;
using ImpisAPI.Application.Interfaces;
using ImpisAPI.Domain.Entities;
using ImpisAPI.Domain.Repositories;

namespace ImpisAPI.Application.Services
{
    public class IdealResultService : IIdealResultService
    {
        private readonly IIdealResultRepository _idealResultRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public IdealResultService(IIdealResultRepository idealResultRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _idealResultRepository = idealResultRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<IdealResultDto>> GetAllAsync()
        {
            var results = await _idealResultRepository.GetAllAsync();

            var resultsDto = _mapper.Map<IEnumerable<IdealResultDto>>(results);

            return resultsDto;
        }

        public async Task<IEnumerable<IdealResultDto>> GetByTypeId(Guid typeId)
        {
            var results = await _idealResultRepository.GetByTypeIdAsync(typeId);

            var resultsDto = _mapper.Map<IEnumerable<IdealResultDto>>(results);

            return resultsDto;
        }

        public async Task<IdealResultDto> GetByIdAsync(Guid id)
        {
            var result = await _idealResultRepository.GetByIdAsync(id);

            var resultDto = _mapper.Map<IdealResultDto>(result);

            return resultDto;
        }

        public async Task CreateAsync(IdealResultDto resultDto)
        {
            var result = _mapper.Map<IdealResult>(resultDto);
            _idealResultRepository.Create(result);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(IdealResultDto resultDto)
        {
            var result = _mapper.Map<IdealResult>(resultDto);
            
            _idealResultRepository.Update(result);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task RemoveAsync(Guid resultId)
        {
            var result = await _idealResultRepository.GetByIdAsync(resultId);
            
            _idealResultRepository.Delete(result);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}