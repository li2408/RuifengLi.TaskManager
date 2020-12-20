using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Entities;

namespace TaskManager.Core.ServiceInterfaces
{
    public interface ITaskHistoryService
    {
        public Task<IEnumerable<TaskHistory>> GetTaskHistoryById(int id);
        public Task<IEnumerable<TaskHistory>> GetAllTaskHistory();
        public System.Threading.Tasks.Task AddTaskHistory(TaskHistory taskHistory);
        public Task<TaskHistory> UpdateTaskHistory(TaskHistory taskHistory);
        public System.Threading.Tasks.Task DeleteTaskHistory(TaskHistory taskHistory);
      
    }
}
