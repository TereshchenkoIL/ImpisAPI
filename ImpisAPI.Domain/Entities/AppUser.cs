using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace ImpisAPI.Domain.Entities
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
        
        public ICollection<UserPhoto> Photos { get; set; }
    }
}