using System;
using System.Threading.Tasks;
using ImpisAPI.Application.DTOs;
using ImpisAPI.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ImpisApi.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuggestionsController : ControllerBase
    {
        private readonly ISuggestionService _suggestionService;

        public SuggestionsController(ISuggestionService suggestionService)
        {
            _suggestionService = suggestionService;
        }

        [HttpGet("type/{typeId:guid}")]
        public async Task<IActionResult> GetAllByTypeId(Guid typeId)
        {
            var result = await _suggestionService.GetAllByTypeIdAsync(typeId);
            return Ok(result);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _suggestionService.GetAllAsync();
            return Ok(result);
        }
        
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _suggestionService.GetByIdAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(SuggestionDto suggestionDto)
        {
            await _suggestionService.CreateAsync(suggestionDto);
            return Ok();
        }
        
        [HttpPut]
        public async Task<IActionResult> Update(SuggestionDto suggestionDto)
        {
            await _suggestionService.UpdateAsync(suggestionDto);
            return Ok();
        }
        
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _suggestionService.DeleteAsync(id);
            return Ok();
        }
    }
}