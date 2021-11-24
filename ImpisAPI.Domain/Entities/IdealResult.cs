using System;
using ImpisAPI.Domain.Interfaces;

namespace ImpisAPI.Domain.Entities
{
    public class IdealResult : IEntity
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public double Weight { get; set; }
        public Period Period { get; set; }
        public ReservoirType Type { get; set; }
    }
}