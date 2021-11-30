using System.Threading.Tasks;
using ImpisAPI.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImpisApi.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserPhotosController : ControllerBase
    {
        private readonly IUserPhotoService _photoService;
        public UserPhotosController(IUserPhotoService photoService) 
        {
            _photoService = photoService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] IFormFile file)
        {
            var photo = await _photoService.CreateAsync(file);

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