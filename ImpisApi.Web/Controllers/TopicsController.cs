using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ImpisAPI.Application.DTOs;
using ImpisAPI.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ImpisApi.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TopicsController : ControllerBase
    {
        private readonly ITopicService _topicService;

        public TopicsController(ITopicService topicService) 
        {
            _topicService = topicService;
        }
           
        [AllowAnonymous]
        [HttpGet("all")]
        public async Task<ActionResult<List<TopicDto>>> GetAllTopics()
        {
            var topics = await _topicService.GetAllAsync();

            return Ok(topics);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<List<TopicDto>>> GetTopicById(Guid id)
        {
            var topic = await _topicService.GetByIdAsync(id);

            return Ok(topic);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTopic(TopicDto topic)
        {
            await _topicService.CreateAsync(topic);

            return Ok();
        }
       
        [HttpPut("{topicId}")]
        public async Task<IActionResult> EditTopic(Guid topicId, TopicDto topicDto)
        {
            await _topicService.UpdateAsync(topicDto);
            return Ok();
        }

        
        [HttpDelete("{topicId}")]
        public async Task<IActionResult> DeleteTopic(Guid topicId)
        {
            await _topicService.DeleteAsync(topicId);
            return Ok();
        }

      
       
    }
}