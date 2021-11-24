using System;
using ImpisAPI.Domain.Interfaces;

namespace ImpisAPI.Domain.Entities
{
    public class UserPhoto : IEntity
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Url { get; set; }
        public AppUser User { get; set; }
    }
}