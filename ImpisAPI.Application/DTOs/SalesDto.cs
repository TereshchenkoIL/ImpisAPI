using System;

namespace ImpisAPI.Application.DTOs
{
    public class SalesDto
    {
        public Guid Id { get; set; }
        public double Weight { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}