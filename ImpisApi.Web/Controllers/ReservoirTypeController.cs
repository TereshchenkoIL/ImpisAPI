using System;
using System.Threading.Tasks;
using ImpisAPI.Application.DTOs;
using ImpisAPI.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ImpisApi.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservoirTypeController : ControllerBase
    {
        private readonly IReservoirTypeService _reservoirTypeService;

        public ReservoirTypeController(IReservoirTypeService reservoirTypeService)
        {
            _reservoirTypeService = reservoirTypeService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _reservoirTypeService.GetAllAsync();
            return Ok(result);
        }
        
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _reservoirTypeService.GetByIdAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(ReservoirTypeDto reservoirType)
        {
            await _reservoirTypeService.CreateAsync(reservoirType);
            return Ok();
        }
        
        [HttpPut]
        public async Task<IActionResult> Update(ReservoirTypeDto reservoirType)
        {
            await _reservoirTypeService.UpdateAsync(reservoirType);
            return Ok();
        }
        
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _reservoirTypeService.DeleteAsync(id);
            return Ok();
        }
    }
}