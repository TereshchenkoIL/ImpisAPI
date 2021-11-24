﻿namespace ImpisAPI.Application.DTOs
{
    public class Profile
    {
        
        public string Username { get; set; }

        public string DisplayName { get; set; }

        public string Bio { get; set; }

        public string Image { get; set; }
    
        public int TopicsCount { get; set; }

        public PhotoDto Photo { get; set; }
    }
}