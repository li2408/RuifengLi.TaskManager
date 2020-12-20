using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Core.Entities;
using TaskManager.Core.ServiceInterfaces;

namespace TaskManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskHistoryController : ControllerBase
    {
        private readonly ITaskHistoryService _taskHistoryService;
        public TaskHistoryController(ITaskHistoryService taskHistoryService)
        {
            _taskHistoryService = taskHistoryService;
        }
        [HttpGet] //this is a Get method
        [Route("alltaskhistory")] //this is a route
        public async Task<IActionResult> GetAllTaskHistory()
        {
            var history = await _taskHistoryService.GetAllTaskHistory();
            if (history == null)
            {
                return NotFound("no taskHistory Found");
            }
            return Ok(history);
        }

        [HttpPost]
        [Route("addtaskhistory")]
        public async Task<IActionResult> AddTaskHistory(TaskHistory taskHistory)
        {
            await _taskHistoryService.AddTaskHistory(taskHistory);
            return Ok();
        }

        [HttpDelete]
        [Route("deletetaskhistory")]
        public async Task<IActionResult> DeleteTaskHistory(TaskHistory taskHistory)
        {
            await _taskHistoryService.DeleteTaskHistory(taskHistory);
            return Ok();
        }

        [HttpPut]
        [Route("updatetaskhistory")]
        public async Task<IActionResult> UpdateTaskHistory(TaskHistory taskHistory)
        {
            await _taskHistoryService.UpdateTaskHistory(taskHistory);
            return Ok();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetTaskHistoryById(int id)
        {
            var taskHistories = await _taskHistoryService.GetTaskHistoryById(id);
            return Ok(taskHistories);
        }
    }
}
