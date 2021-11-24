using System;
using ImpisAPI.Domain.Interfaces;

namespace ImpisAPI.Domain.Entities
{
    public class Suggestion : IEntity
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Text { get; set; }
        public ReservoirType Type { get; set; }
    }
}