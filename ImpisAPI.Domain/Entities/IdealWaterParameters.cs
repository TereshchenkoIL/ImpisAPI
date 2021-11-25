using System;
using ImpisAPI.Domain.Interfaces;

namespace ImpisAPI.Domain.Entities
{
    public class IdealWaterParameters : IEntity
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public float Temperature { get; set; }
        public float Ph { get; set; }
        public float Turbidity{ get; set; }
        public Period Period { get; set; }
        public ReservoirType Type { get; set; }
    }
}