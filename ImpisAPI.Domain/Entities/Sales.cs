using System;
using ImpisAPI.Domain.Interfaces;

namespace ImpisAPI.Domain.Entities
{
    public class Sales : IEntity
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public Reservoir Reservoir { get; set; }
        public double Weight { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}