using System;
using System.Collections.Generic;

namespace ImpisAPI.Application.DTOs
{
    public class ReservoirDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int SpecQuantity { get; set; }
        public ReservoirTypeDto Type { get; set; }
        public string Image { get; set; }
        public string Background { get; set; }
        public ICollection<WaterParametersDto> WaterParameters { get; set; }
        public ICollection<SalesDto> Sales { get; set; }
    }
}