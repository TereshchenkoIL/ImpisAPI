using System;
using System.Threading.Tasks;
using ImpisAPI.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImpisApi.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservoirPhotoController : ControllerBase
    {
        private readonly IReservoirPhotoService _photoService;

        public ReservoirPhotoController(IReservoirPhotoService photoService)
        {
            _photoService = photoService;
        }


        [HttpPost("{reservoirId:guid}")]
        public async Task<IActionResult> Add(Guid reservoirId, [FromForm] IFormFile file)
        {
            var photo = await _photoService.CreateAsync(file, reservoirId);

            return Ok(photo);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _photoService.DeleteAsync(id);
            return Ok();
        }
    }
}