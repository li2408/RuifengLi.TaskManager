using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Core.Models.Request;
using TaskManager.Core.ServiceInterfaces;

namespace TaskManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        // api/tasks/alltasks
        [HttpGet] //this is a Get method
        [Route("alltasks")] //this is a route
        public async Task<IActionResult> GetAllTasks() {
            var tasks = await _taskService.GetAllTasks();
            if (tasks==null)
            {
                return NotFound("no tasks Found");
            }
            return Ok(tasks);
        }

        // api/tasks/addTask
        [HttpPost] 
        [Route("addTask")] 
        public async Task<IActionResult> AddTask(TaskCreateRequestModel requestModel) {
            await _taskService.CreateTask(requestModel);
            return Ok();
        }

        // api/tasks/deleteTask
        [HttpDelete]
        [Route("deleteTask")]
        public async Task<IActionResult> DeleteTask(TaskManager.Core.Entities.Task task) {
            var deletedTask = await _taskService.DeleteTask(task);
            return Ok(deletedTask);
        }

        [HttpPut]
        [Route("updateTask")]
        public async Task<IActionResult> UpdateTask(TaskManager.Core.Entities.Task task) {
            await _taskService.UpdateTask(task);
            return Ok();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetTaskById(int id) {
            var task = await _taskService.GetTaskById(id);
            return Ok(task);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteTaskById(int id)
        {
            var task = await _taskService.DeleteTaskById(id);
            return Ok(task);
        }
    }
}
