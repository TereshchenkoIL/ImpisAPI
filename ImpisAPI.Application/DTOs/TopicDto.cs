using System;

namespace ImpisAPI.Application.DTOs
{
    public class TopicDto
    {
        public Guid Id { get; set; }
        
        public string Title { get; set; }
        
        public string Body { get; set; }
        
        public DateTime CreatedAt { get; set; }

        public Profile Creator { get; set; }
        
    }
}