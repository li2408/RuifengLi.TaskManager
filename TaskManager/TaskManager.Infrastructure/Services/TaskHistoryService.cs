using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Entities;
using TaskManager.Core.RepositoryInterfaces;
using TaskManager.Core.ServiceInterfaces;

namespace TaskManager.Infrastructure.Services
{
    public class TaskHistoryService : ITaskHistoryService
    {
        private readonly ITaskHistoryRepository _taskHistoryRepository;
        public TaskHistoryService(ITaskHistoryRepository taskHistoryRepository)
        {
            _taskHistoryRepository = taskHistoryRepository;
        }

        //get the task by its id
        public async Task<IEnumerable<TaskHistory>> GetTaskHistoryById(int id) {
            var taskHistories = await _taskHistoryRepository.GetTaskHistoriesById(id);
            return taskHistories;
            
        }

        //get all of the tasks.
        public async Task<IEnumerable<TaskHistory>> GetAllTaskHistory() {
            var taskHistories = await _taskHistoryRepository.ListAllAsync();
            return taskHistories;
        }

        //add a task history.
        public async System.Threading.Tasks.Task AddTaskHistory(TaskHistory taskHistory)
        {
            await _taskHistoryRepository.AddAsync(taskHistory);
        }

        //update a task history:
        public async Task<TaskHistory> UpdateTaskHistory(TaskHistory taskHistory) {
            await _taskHistoryRepository.UpdateAsync(taskHistory);
            return taskHistory;
        }

        //delete a task history:
        public async System.Threading.Tasks.Task DeleteTaskHistory(TaskHistory taskHistory) {
            await _taskHistoryRepository.DeleteAsync(taskHistory);
        }

    }
}
