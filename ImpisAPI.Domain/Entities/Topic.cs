using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ImpisAPI.Domain.Interfaces;

namespace ImpisAPI.Domain.Entities
{
    public class Topic : IEntity
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }

        public AppUser Creator { get; set; }
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}