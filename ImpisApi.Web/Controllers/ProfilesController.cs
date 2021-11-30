using System.Threading.Tasks;
using ImpisAPI.Application.Interfaces;
using ImpisAPI.Domain.Entities;
using ImpisApi.Web.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ImpisApi.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfilesController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IProfileService _profileService;
        private readonly ITopicService _topicService;
        public ProfilesController(UserManager<AppUser> userManager, IProfileService profileService, ITopicService topicService)
        {
            _userManager = userManager;
            _profileService = profileService;
            _topicService = topicService;
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> GetProfile(string username)
        {
            var profile = await _profileService.GetDetails(username);

            return Ok(profile);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProfile(UserUpdateDto userUpdateDto)
        {
            var profile = await _profileService.UpdateAsync(userUpdateDto.DisplayName, userUpdateDto.Bio);

            return Ok(profile);
        }

        [HttpGet("{username}/topics")]
        public async Task<IActionResult> GetTopics(string username)
        {
            var topics = await _topicService.GetAllByCreatorUsernameAsync(username);
            return Ok(topics);
        }
        
    }
}