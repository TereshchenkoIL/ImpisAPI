using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ImpisAPI.Application.DTOs;
using ImpisAPI.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ImpisApi.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IdealResultController : ControllerBase
    {
        private readonly IIdealResultService _idealResultService;

        public IdealResultController(IIdealResultService idealResultService)
        {
            _idealResultService = idealResultService;
        }

        [HttpGet("type/{typeId:guid}")]
        public async Task<IActionResult> GetAllByTypeId(Guid typeId)
        {
            var result = await _idealResultService.GetByTypeId(typeId);
            return Ok(result);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _idealResultService.GetAllAsync();
            return Ok(result);
        }
        
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _idealResultService.GetByIdAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(IdealResultDto resultForCreation)
        {
            await _idealResultService.CreateAsync(resultForCreation);
            return Ok();
        }
        
        [HttpPut]
        public async Task<IActionResult> Update(IdealResultDto resultForUpdate)
        {
            await _idealResultService.UpdateAsync(resultForUpdate);
            return Ok();
        }
        
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _idealResultService.RemoveAsync(id);
            return Ok();
        }
    }
}