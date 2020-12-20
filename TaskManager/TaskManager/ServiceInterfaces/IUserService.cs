using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Entities;
using TaskManager.Core.Models.Request;

namespace TaskManager.Core.ServiceInterfaces
{
    public interface IUserService
    {
        public Task<UserCreateResponseModel> CreateUser(UserCreateRequestModel requestModel);
        public Task<User> DeleteUser(User user);
        public Task<User> UpdateUser(User user);
        public Task<IEnumerable<User>> GetAllUsers();
        public Task<User> GetUserById(int id);
    }
}
