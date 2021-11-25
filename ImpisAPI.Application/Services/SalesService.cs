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
    public class SalesService : ISalesService
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public SalesService(ISaleRepository saleRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<SalesDto>> GetAllAsync()
        {
            var sales = await _saleRepository.GetAllAsync();
            var salesDto = _mapper.Map<IEnumerable<SalesDto>>(sales);
            return salesDto;
        }

        public async Task<IEnumerable<SalesDto>> GetAllByReservoirIdAsync(Guid reservoirId)
        {
            var sales = await _saleRepository.GetAllByReservoirIdAsync(reservoirId);
            var salesDto = _mapper.Map<IEnumerable<SalesDto>>(sales);
            return salesDto;
        }

        public async Task CreateAsync(SalesDto salesDto)
        {
            var sales = _mapper.Map<Sales>(salesDto);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid salesId)
        {
            var sales = await _saleRepository.GetByIdAsync(salesId);
            _saleRepository.Delete(sales);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}