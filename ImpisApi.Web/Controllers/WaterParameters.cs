using System;
using System.Threading.Tasks;
using ImpisAPI.Application.DTOs;
using ImpisAPI.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ImpisApi.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WaterParametersController: ControllerBase
    {
        private readonly  IWaterParametersService _waterParametersService;

        public WaterParametersController(IWaterParametersService waterParametersService)
        {
            _waterParametersService = waterParametersService;
        }


        [HttpGet("reservoir/{reservoirId:guid}")]
        public async Task<IActionResult> GetByReservoirId(Guid reservoirId)
        {
            var result = await _waterParametersService.GetAllByReservoirIdAsync(reservoirId);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _waterParametersService.GetAllAsync();
            return Ok(result);
        }
        
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _waterParametersService.GetByIdAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(WaterParametersDto waterParametersDto)
        {
            await _waterParametersService.CreateAsync(waterParametersDto);
            return Ok();
        }
        
        
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _waterParametersService.DeleteAsync(id);
            return Ok();
        }
    }
}