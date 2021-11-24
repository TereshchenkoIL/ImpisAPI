using System;
using ImpisAPI.Domain.Interfaces;

namespace ImpisAPI.Domain.Entities
{
    public class UserPhoto 
    {
        public string Id { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsMain { get; set; }
        public string Url { get; set; }
        public AppUser User { get; set; }
    }
}