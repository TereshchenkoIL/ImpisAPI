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
    public class SuggestionService : ISuggestionService
    {
        private readonly ISuggestionRepository _suggestionRepository;
        private readonly IMapper _mapper;
        private readonly IReservoirTypeRepository _reservoirTypeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SuggestionService(ISuggestionRepository suggestionRepository, IMapper mapper, IUnitOfWork unitOfWork, IReservoirTypeRepository reservoirTypeRepository)
        {
            _suggestionRepository = suggestionRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _reservoirTypeRepository = reservoirTypeRepository;
        }

        public async Task<IEnumerable<SuggestionDto>> GetAllAsync()
        {
            var suggestions = await _suggestionRepository.GetAllAsync();
            var suggestionDto = _mapper.Map<IEnumerable<SuggestionDto>>(suggestions);
            return suggestionDto;
        }

        public async Task<IEnumerable<SuggestionDto>> GetAllByTypeIdAsync(Guid typeId)
        {
            var suggestions = await _suggestionRepository.GetAllByTypeIdAsync(typeId);
            var suggestionDto = _mapper.Map<IEnumerable<SuggestionDto>>(suggestions);
            return suggestionDto;
        }

        public async Task<SuggestionDto> GetByIdAsync(Guid id)
        {
            var suggestion = await _suggestionRepository.GetByIdAsync(id);
            var suggestionDto = _mapper.Map<SuggestionDto> (suggestion);
            return suggestionDto;
        }

        public async Task CreateAsync(SuggestionDto suggestionDto)
        {
            var type = await _reservoirTypeRepository.GetByIdAsync(suggestionDto.Type.Id);
            var suggestion = _mapper.Map<Suggestion>(suggestionDto);
            suggestion.Id = Guid.Empty;
            suggestion.Type = null;
            type.Suggestions.Add(suggestion);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(SuggestionDto suggestionDto)
        {
            var suggestion = _mapper.Map<Suggestion>(suggestionDto);
           _suggestionRepository.Update(suggestion);
           await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid suggestionId)
        {
            var suggestion = await _suggestionRepository.GetByIdAsync(suggestionId);
            _suggestionRepository.Delete(suggestion);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}