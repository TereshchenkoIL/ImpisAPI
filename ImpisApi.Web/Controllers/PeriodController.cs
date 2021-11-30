using System;
using System.Threading.Tasks;
using ImpisAPI.Application.DTOs;
using ImpisAPI.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ImpisApi.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeriodController : ControllerBase
    {
        private readonly IPeriodService _periodService;

        public PeriodController(IPeriodService periodService)
        {
            _periodService = periodService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _periodService.GetAllAsync();
            return Ok(result);
        }
        
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _periodService.GetByIdAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(PeriodDto periodDto)
        {
            await _periodService.CreateAsync(periodDto);
            return Ok();
        }
        
        [HttpPut]
        public async Task<IActionResult> Update(PeriodDto periodDto)
        {
            await _periodService.UpdateAsync(periodDto);
            return Ok();
        }
        
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _periodService.DeleteAsync(id);
            return Ok();
        }
    }
}