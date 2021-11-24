using System;

namespace ImpisAPI.Application.DTOs
{
    public class WaterParametersDto
    {
        public Guid Id { get; set; }
        public float Temperature { get; set; }
        public float Ph { get; set; }
        public float Turbidity{ get; set; }
        public DateTime MeasuredAt { get; set; } = DateTime.UtcNow;
    }
}