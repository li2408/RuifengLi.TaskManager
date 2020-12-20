using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Core.Entities;
using TaskManager.Core.Models.Request;
using TaskManager.Core.ServiceInterfaces;

namespace TaskManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // api/users/allusers
        [HttpGet] //this is a Get method
        [Route("allusers")] //this is a route
        public async Task<IActionResult> GetAllUsers() {
            var users = await _userService.GetAllUsers();
            if (users == null)
            {
                return NotFound("no users Found");
            }
            return Ok(users);
        }
        // api/users/adduser
        [HttpPost]
        [Route("adduser")]
        public async Task<IActionResult> AddTask(UserCreateRequestModel requestModel) {
            await _userService.CreateUser(requestModel);
            return Ok();
        }

        // api/tasks/deleteTask
        [HttpDelete]
        [Route("deleteuser")]
        public async Task<IActionResult> DeleteUser(User user)
        {
            var deletedTask = await _userService.DeleteUser(user);
            return Ok(deletedTask);
        }

        [HttpPut]
        [Route("updateuser")]
        public async Task<IActionResult> UpdateUser(User user) {
            await _userService.UpdateUser(user);
            return Ok();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            return Ok(user);
        }
    }
}
