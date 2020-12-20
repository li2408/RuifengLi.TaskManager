using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Entities;
using TaskManager.Core.Models.Request;
using TaskManager.Core.RepositoryInterfaces;
using TaskManager.Core.ServiceInterfaces;

namespace TaskManager.Infrastructure.Repositories
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICryptoService _encryptionService;
        public UserService(IUserRepository userRepository, ICryptoService encryptionService)
        {
            _userRepository = userRepository;
            _encryptionService = encryptionService;
        }
        //add a user:
        public async Task<UserCreateResponseModel> CreateUser(UserCreateRequestModel requestModel)
        {
            //step1: create an user
            //step2: add the created user to the userRepository
            //step3: send the response back to the controller. (important)

            //make sure email does not exist in the database
            //we need to send email to our User repository and see if the data exists for the email
            var dbUser = await _userRepository.GetUserByEmail(requestModel.Email);
            //if the user exists and there's an email that matches it.
            if (dbUser != null && string.Equals(dbUser.Email, requestModel.Email, StringComparison.CurrentCultureIgnoreCase))
                throw new Exception("Email Already Exits");

            //First step is to create a unique random salt.
            var salt = _encryptionService.CreateSalt();
            var hashedPassword = _encryptionService.HashPassword(requestModel.Password, salt);
            var user = new User
            {
                Email = requestModel.Email,
                Password = requestModel.Password,
                Fullname = requestModel.Fullname,
                Mobileno = requestModel.Mobileno
            };
            var createdUser = await _userRepository.AddAsync(user);
            var response = new UserCreateResponseModel
            {
                Email = createdUser.Email,
                Password = createdUser.Password,
                Fullname = createdUser.Fullname,
                Mobileno = createdUser.Mobileno
            };
            return response;
        }

        // delete a user:
        public async Task<User> DeleteUser(User user) {
            await _userRepository.DeleteAsync(user);
            return user;
        }

        //update a user:
        public async Task<User> UpdateUser(User user) {
            await _userRepository.UpdateAsync(user);
            return user;
        }

        //get all the users
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var users = await _userRepository.ListAllAsync();
            return users;
        }

        public async Task<User> GetUserById(int id) {
            var user = await _userRepository.GetByIdAsync(id);
            return user;
        }
    }
}