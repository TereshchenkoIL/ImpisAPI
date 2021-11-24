using System;
using System.ComponentModel.DataAnnotations;
using ImpisAPI.Domain.Interfaces;

namespace ImpisAPI.Domain.Entities
{
    public class Comment : IEntity
    {
        [Required]
        public string Body { get; set; } 
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
       
        public AppUser Author { get; set; }
        
        public Topic Topic { get; set; }


        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}