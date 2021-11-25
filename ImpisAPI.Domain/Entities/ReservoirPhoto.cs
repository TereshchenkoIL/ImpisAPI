using System;
using ImpisAPI.Domain.Interfaces;

namespace ImpisAPI.Domain.Entities
{
    public class ReservoirPhoto 
    {
        public string Id { get; set; }
        public bool IsDeleted { get; set; }
        public Reservoir Reservoir { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
        public bool IsBackground { get; set; }
    }
}