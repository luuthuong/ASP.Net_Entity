using Netpower.Training.Intern2022.API.DTO;
using Netpower.Training.Intern2022.API.Entities;
using Netpower.Training.Intern2022.API.Repositories.Repostiory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Netpower.Training.Intern2022.API.Services
{
    public class ProfileService
    {
        private readonly ProfileRepository _profiles;
        public ProfileService(ProfileRepository profiles)
        {
            _profiles = profiles;
        }
        public async Task<List<Profile>> GetProfileAsync()
        {
            return await _profiles.GetDataAsync();
        }
        public async Task<Profile> GetProfileAsync(Guid ID)
        {
            return await _profiles.GetDataAsync(ID);
        }
        public async Task<ProfileDTO> InsertProfileAsync(ProfileDTO profile)
        {
            var newProfile = new Profile()
            {
                Age = profile.Age,
                Name = profile.Name,
                Sex = profile.Sex,
                ID = Guid.NewGuid(),
                CreateAt = DateTime.Now,
                PositionID = profile.ID,
                UserID = profile.UserID
            };
            await _profiles.AddDataAsync(newProfile);
            return profile;
        }
        public async Task<Profile> UpdateProfileAsync(Guid ID,ProfileDTO profile)
        {
            var result=await _profiles.CheckExistAsync(ID);
            if (result == null)
                return null;
            result.PositionID = profile.ID;
            result.UserID=profile.UserID;
            result.Name = profile.Name;
            result.Age = profile.Age;
            result.Sex = profile.Sex;
            await _profiles.UpdateDataAsync(result);
            return result;
        }
        public async Task<Profile> DeleteProfileAsync(Guid ID)
        {
            var result = await _profiles.CheckExistAsync(ID);
            if (result == null)
                return null;
            await _profiles.DeleteData(result);
            return result;
        }
    }
}
