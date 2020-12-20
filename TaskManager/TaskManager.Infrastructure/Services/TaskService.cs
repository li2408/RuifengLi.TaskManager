using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Models.Request;
using TaskManager.Core.RepositoryInterfaces;
using TaskManager.Core.ServiceInterfaces;

namespace TaskManager.Infrastructure.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        //add a task:
        public async Task<TaskCreateResponseModel> CreateTask(TaskCreateRequestModel requestModel) {
            var task = new TaskManager.Core.Entities.Task
            {
                UserId = requestModel.UserId,
                Title = requestModel.Title,
                Description = requestModel.Description,
                DueDate = requestModel.DueDate,
                Priority = requestModel.Priority,
                Remarks = requestModel.Remarks
            };
            await _taskRepository.AddAsync(task);
            var createdTask = new TaskCreateResponseModel()
            {
                UserId = (int)task.UserId,
                Title = task.Title,
                Description = task.Description,
                DueDate = (DateTime)task.DueDate,
                Priority = (char)task.Priority,
                Remarks = task.Remarks
            };
            return createdTask;
        }

        // delete a task:
        public async Task<TaskManager.Core.Entities.Task> DeleteTask(TaskManager.Core.Entities.Task task) {
            await _taskRepository.DeleteAsync(task);
            return task;
        }

        //update a task:
        public async Task<TaskManager.Core.Entities.Task> UpdateTask(TaskManager.Core.Entities.Task task) {
            await _taskRepository.UpdateAsync(task);
            return task;
        }

        //get all the tasks:
        public async Task<IEnumerable<TaskManager.Core.Entities.Task>> GetAllTasks() {
            var tasks = await _taskRepository.ListAllAsync();
            return tasks;
        }

        //get task by user's id.
        public async Task<IEnumerable<Core.Entities.Task>> GetTaskById(int id)
        {
            //find all the tasks from this user.
            var tasks = await _taskRepository.ListAsync(tr => tr.UserId == id ); 
            return tasks;
        }

        public async Task<TaskManager.Core.Entities.Task> DeleteTaskById(int id) {
            var deletedTask = await _taskRepository.DeleteTaskById(id);
            return deletedTask;
        }
    }
}
