using System;
using System.Threading.Tasks;
using ImpisAPI.Application.DTOs;
using ImpisAPI.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ImpisApi.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservoirController : ControllerBase
    {
        private readonly IReservoirService _reservoirService;

        public ReservoirController(IReservoirService reservoirService)
        {
            _reservoirService = reservoirService;
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetAllByUserId(string userId)
        {
            var result = await _reservoirService.GetAllByUserIdAsync(userId);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _reservoirService.GetAllAsync();
            return Ok(result);
        }
        
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _reservoirService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReservoirDto reservoirDto)
        {
            await _reservoirService.CreateAsync(reservoirDto);
            return Ok();
        }
        
        
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _reservoirService.DeleteAsync(id);
            return Ok();
        }
    }
}