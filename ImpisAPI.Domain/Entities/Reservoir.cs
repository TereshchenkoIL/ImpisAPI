using System;
using System.Collections;
using System.Collections.Generic;
using ImpisAPI.Domain.Interfaces;

namespace ImpisAPI.Domain.Entities
{
    public class Reservoir : IEntity
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public AppUser Owner { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int SpecQuantity { get; set; }
        public ReservoirType Type { get; set; }
        public ICollection<ReservoirPhotos> Photos { get; set; }
        public ICollection<WaterParameters> WaterParameters { get; set; }
        public ICollection<Sales> Sales { get; set; }
    }
}