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
    public class IdealWaterParametersService : IIdealWaterParametersService
    {
        private readonly IIdealWaterParametersRepository _waterParametersRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public IdealWaterParametersService(IIdealWaterParametersRepository waterParametersRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _waterParametersRepository = waterParametersRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<IdealWaterParametersDto>> GetAllAsync()
        {
            var parameters = await _waterParametersRepository.GetAllAsync();

            var parametersDto = _mapper.Map<IEnumerable<IdealWaterParametersDto>>(parameters);

            return parametersDto;
        }

        public async Task<IEnumerable<IdealWaterParametersDto>> GetByTypeId(Guid typeId)
        {
            var parameters = await _waterParametersRepository.GetByTypeIdAsync(typeId);

            var parametersDto = _mapper.Map<IEnumerable<IdealWaterParametersDto>>(parameters);

            return parametersDto;
        }

        public async Task<IdealWaterParametersDto> GetByIdAsync(Guid parameterId)
        {
            var parameter = await _waterParametersRepository.GetByIdAsync(parameterId);

            var parameterDto = _mapper.Map<IdealWaterParametersDto>(parameter);

            return parameterDto;
        }

        public async Task CreateAsync(IdealWaterParametersDto parameters)
        {
            var parameter = _mapper.Map<IdealWaterParameters>(parameters);
            _waterParametersRepository.Create(parameter);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(IdealWaterParametersDto parameters)
        {
            var parameter = _mapper.Map<IdealWaterParameters>(parameters);
            _waterParametersRepository.Update(parameter);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid parameterId)
        {
            var parameter = await _waterParametersRepository.GetByIdAsync(parameterId);
            _waterParametersRepository.Delete(parameter);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}