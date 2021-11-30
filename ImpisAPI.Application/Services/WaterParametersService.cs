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
    public class WaterParametersService : IWaterParametersService
    {
        private readonly IWaterParametersRepository _waterParametersRepository;
        private readonly IReservoirRepository _reservoirRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public WaterParametersService(IWaterParametersRepository waterParametersRepository, IMapper mapper, IReservoirRepository reservoirRepository, IUnitOfWork unitOfWork)
        {
            _waterParametersRepository = waterParametersRepository;
            _mapper = mapper;
            _reservoirRepository = reservoirRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<WaterParametersDto>> GetAllAsync()
        {
            var parameters = await _waterParametersRepository.GetAllAsync();

            var parametersDto = _mapper.Map<IEnumerable<WaterParametersDto>>(parameters);

            return parametersDto;
        }

        public async Task<IEnumerable<WaterParametersDto>> GetAllByReservoirIdAsync(Guid reservoirId)
        {
            var parameters = await _waterParametersRepository.GetAllByReservoirIdAsync(reservoirId);

            var parametersDto = _mapper.Map<IEnumerable<WaterParametersDto>>(parameters);

            return parametersDto;
        }

        public async Task<WaterParametersDto> GetByIdAsync(Guid id)
        {
            var parameter = await _waterParametersRepository.GetByIdAsync(id);

            var parameterDto = _mapper.Map<WaterParametersDto>(parameter);

            return parameterDto;
        }

        public async Task CreateAsync(WaterParametersDto waterParameters)
        {
            var parameter = _mapper.Map<WaterParameters>(waterParameters);

            var reservoir = await _reservoirRepository.GetByIdAsync(parameter.Reservoir.Id);

            parameter.Reservoir = reservoir;
            _waterParametersRepository.Create(parameter);

            await _unitOfWork.SaveChangesAsync();

        }

        public async Task DeleteAsync(Guid parametersId)
        {
            var parameter = await _waterParametersRepository.GetByIdAsync(parametersId);
            _waterParametersRepository.Delete(parameter);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}