using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ImpisAPI.Application.DTOs;

namespace ImpisAPI.Application.Interfaces
{
    public interface IProfileService
    {
        Task<Profile> GetDetails(string username);

      
        Task<Profile> UpdateAsync(string displayName, string bio);
        
        Task<Profile> UpdateAsync(string username, string displayName, string bio);



    }
}