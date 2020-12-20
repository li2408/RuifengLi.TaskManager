using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Models.Request;

namespace TaskManager.Core.ServiceInterfaces
{
    public interface ITaskService
    {
        public Task<TaskCreateResponseModel> CreateTask(TaskCreateRequestModel requestModel);
        public Task<TaskManager.Core.Entities.Task> DeleteTask(TaskManager.Core.Entities.Task task);
        public Task<TaskManager.Core.Entities.Task> UpdateTask(TaskManager.Core.Entities.Task task);
        public Task<IEnumerable<TaskManager.Core.Entities.Task>> GetAllTasks();
        public Task<IEnumerable<Core.Entities.Task>> GetTaskById(int id);
        public Task<Core.Entities.Task> DeleteTaskById(int id);
    }
}
