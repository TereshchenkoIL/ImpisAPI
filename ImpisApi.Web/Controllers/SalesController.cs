using System;
using System.Threading.Tasks;
using ImpisAPI.Application.DTOs;
using ImpisAPI.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ImpisApi.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly ISalesService _salesService;

        public SalesController(ISalesService salesService)
        {
            _salesService = salesService;
        }

        [HttpGet("reservoir/{reservoirId:guid}")]
        public async Task<IActionResult> GetByReservoirId(Guid reservoirId)
        {
            var result = await _salesService.GetAllByReservoirIdAsync(reservoirId);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _salesService.GetAllAsync();
            return Ok(result);
        }
        
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _salesService.GetByIdAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(SalesDto salesDto)
        {
            await _salesService.CreateAsync(salesDto);
            return Ok();
        }
        
        
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _salesService.DeleteAsync(id);
            return Ok();
        }
    }
}