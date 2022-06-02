using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ImpisAPI.Application.Interfaces;
using ImpisAPI.Domain.Interfaces;
using ImpisAPI.Domain.Repositories;
using Profile = ImpisAPI.Application.DTOs.Profile;

namespace ImpisAPI.Application.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserAccessor _userAccessor;
        private readonly IUserRepository _userRepository;

        public ProfileService(IUnitOfWork unitOfWork, IMapper mapper, IUserAccessor userAccessor, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userAccessor = userAccessor;
            _userRepository = userRepository;
        }
        public async Task<Profile> GetDetails(string username)
        {
            var user = await _userRepository.GetByUsernameAsync(username);
            
            return _mapper.Map<Profile>(user);
        }

      

        public async Task<Profile> UpdateAsync(string displayName, string bio)
        {
            var username = _userAccessor.GetUsername();

           return await UpdateAsync(username, displayName, bio);

        }

        public async Task<Profile> UpdateAsync(string username, string displayName, string bio)
        {
           
            var user = await _userRepository.GetByUsernameAsync(username);

            if (!string.IsNullOrEmpty(displayName))
            {
                user.DisplayName = displayName;
            }
            var result = await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<Profile>(user);
        }

      
    }
}