using System;

namespace ImpisAPI.Domain.Interfaces
{
    public interface IEntity
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}