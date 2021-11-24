using System;

namespace ImpisAPI.Application.DTOs
{
    public class CommentUpdateDto
    {
        public Guid  Id { get; set; }

        public Guid TopicId { get; set; }
        public string Body { get; set; } 
    }
}