using System;
using ImpisAPI.Domain.Interfaces;

namespace ImpisAPI.Domain.Entities
{
    public class WaterParameters : IEntity
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public float Temperature { get; set; }
        public float Ph { get; set; }
        public float Turbidity{ get; set; }
        public DateTime MeasuredAt { get; set; } = DateTime.UtcNow;
        public Reservoir Reservoir { get; set; }
    }
}