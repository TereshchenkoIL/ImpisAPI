using System;
using System.Threading.Tasks;
using ImpisAPI.Application.DTOs;
using ImpisAPI.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ImpisApi.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IdealWaterParametersController : ControllerBase
    {
        private readonly IIdealWaterParametersService _idealWaterParametersService;

        public IdealWaterParametersController(IIdealWaterParametersService idealWaterParametersService)
        {
            _idealWaterParametersService = idealWaterParametersService;
        }

        [HttpGet("type/{typeId:guid}")]
        public async Task<IActionResult> GetAllByTypeId(Guid typeId)
        {
            var result = await _idealWaterParametersService.GetByTypeId(typeId);
            return Ok(result);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _idealWaterParametersService.GetAllAsync();
            return Ok(result);
        }
        
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _idealWaterParametersService.GetByIdAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(IdealWaterParametersDto waterParametersDto)
        {
            await _idealWaterParametersService.CreateAsync(waterParametersDto);
            return Ok();
        }
        
        [HttpPut]
        public async Task<IActionResult> Update(IdealWaterParametersDto waterParametersDto)
        {
            await _idealWaterParametersService.UpdateAsync(waterParametersDto);
            return Ok();
        }
        
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _idealWaterParametersService.DeleteAsync(id);
            return Ok();
        }
    }
}