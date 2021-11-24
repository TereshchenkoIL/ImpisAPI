using System;
using System.Collections;
using System.Collections.Generic;
using ImpisAPI.Domain.Interfaces;

namespace ImpisAPI.Domain.Entities
{
    public class ReservoirType : IEntity
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public ICollection<Suggestion> Suggestions { get; set; }
        public ICollection<IdealResult> IdealResults { get; set; }
        public ICollection<Reservoir> Reservoirs { get; set; }
    }
}