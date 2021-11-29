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
    public class PeriodService : IPeriodService
    {
        private readonly IPeriodRepository _periodRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PeriodService(IPeriodRepository periodRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _periodRepository = periodRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PeriodDto>> GetAllAsync()
        {
            var periods = await _periodRepository.GetAllAsync();
            var periodDtos = _mapper.Map<IEnumerable<PeriodDto>>(periods);
            return periodDtos;
        }

        public async Task<PeriodDto> GetByIdAsync(Guid periodId)
        {
            var period = await _periodRepository.GetByIdAsync(periodId);
            var periodDto = _mapper.Map<PeriodDto>(period);
            return periodDto;
        }

        public async Task CreateAsync(PeriodDto periodDto)
        {
            var period = _mapper.Map<Period>(periodDto);
            _periodRepository.Create(period);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(PeriodDto periodDto)
        {
            var period = _mapper.Map<Period>(periodDto);
            _periodRepository.Update(period);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid periodId)
        {
            var period = await _periodRepository.GetByIdAsync(periodId);
            
            _periodRepository.Update(period);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}