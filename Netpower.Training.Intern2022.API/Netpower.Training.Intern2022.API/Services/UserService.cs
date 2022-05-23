using Netpower.Training.Intern2022.API.DTO;
using Netpower.Training.Intern2022.API.Entities;
using Netpower.Training.Intern2022.API.Repositories.Repostiory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Netpower.Training.Intern2022.API.Services
{
    public class UserService
    {
        private readonly UserRepository _user;
        public UserService(UserRepository user)
        {
            _user = user;
        }
        public async Task<List<User>> GetUserAsync()
        {
            return await _user.GetDataAsync();
        }
        public async Task<User> GetUserAsync(Guid ID)
        {
            return await _user.GetDataAsync(ID);
        }
        public async Task<UserDTO> InsertUserAsync(UserDTO user)
        {
            bool checkExist = await _user.IsExistNameAsync(user.UserName)>0 && await _user.IsExistMailAsync(user.Email)>0;
            if (checkExist)
                return null;
            var newUser = new User()
            {
                UserName = user.UserName,
                Password = user.Password,
                Email = user.Email,
                CreateAt = DateTime.Now,
                ID = Guid.NewGuid()
            };
            await _user.AddDataAsync(newUser);
            return user;
        }
        public async Task<User> UpdateUserAsync(Guid ID, UserUpdateDTO user)
        {
            var result =await _user.CheckExistAsync(ID);
            bool checkExist =await _user.IsExistMailAsync(user.Email) > 0;
            if (result == null||checkExist)
                return null;
            result.Email = user.Email;
            result.Password = user.Password;
            await _user.UpdateDataAsync(result);
            return result;
        }   
        public async Task<User> DeleteUserAsync(Guid ID)
        {
            var result = await _user.CheckExistAsync(ID);
            if (result == null)
                return null;
            await _user.DeleteData(result);
            return result;
        }
    }
}
