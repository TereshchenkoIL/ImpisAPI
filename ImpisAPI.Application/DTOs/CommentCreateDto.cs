﻿using System;

namespace ImpisAPI.Application.DTOs
{
    public class CommentCreateDto
    {
        public string Body { get; set; }
        public Guid TopicId { get; set; }
        public string Username { get; set; }
        public Guid Id { get; set; }
    }
}