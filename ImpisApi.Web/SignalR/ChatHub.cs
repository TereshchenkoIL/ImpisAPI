using System;
using System.Threading.Tasks;
using ImpisAPI.Application.DTOs;
using ImpisAPI.Application.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace ImpisApi.Web.SignalR
{
    public class ChatHub : Hub
    {
        private readonly ICommentService _commentService;

        public ChatHub(ICommentService commentService)
        {
            _commentService = commentService;
        }

   
        public async Task SendComment(CommentCreateDto commentDto)
        {
            var comment = await _commentService.CreateAsync(commentDto);


            await Clients.Group(commentDto.TopicId.ToString())
                .SendAsync("ReceiveComment", comment);
        }

        public async Task UpdateComment(CommentUpdateDto commentDto)
        {
             await _commentService.UpdateAsync(commentDto);

             var comment = await _commentService.GetByIdAsync(commentDto.Id);

             await Clients.Group(commentDto.TopicId.ToString()).SendAsync("UpdateComment", comment);
        }
        
        public async Task DeleteComment(Guid id)
        {
            var comment = await _commentService.GetByIdAsync(id);
            await _commentService.DeleteAsync(id);
            var httpContext = Context.GetHttpContext();
            var topicId = httpContext.Request.Query["topicId"];
            await Clients.Group(topicId).SendAsync("DeleteComment", id);
        }
        public override async Task OnConnectedAsync()
        {
            var httpContext = Context.GetHttpContext();
            var topicId = httpContext.Request.Query["topicId"];

            await Groups.AddToGroupAsync(Context.ConnectionId, topicId);
            
            var comments = await _commentService.GetAllByTopicAsync(Guid.Parse(topicId));

            await Clients.Caller.SendAsync("LoadComments", comments);
        }

     
    }
}