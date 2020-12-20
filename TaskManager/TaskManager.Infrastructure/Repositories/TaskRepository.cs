using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Entities;
using TaskManager.Core.RepositoryInterfaces;
using TaskManager.Infrastructure.Data;

namespace TaskManager.Infrastructure.Repositories
{
    public class TaskRepository: EfRepository<Core.Entities.Task>, ITaskRepository
    {
        public TaskRepository(TaskManagerDbContext dbContext) : base(dbContext)
        {

        }
        public async Task<TaskManager.Core.Entities.Task> DeleteTaskById(int id)
        {
            TaskManager.Core.Entities.Task task = (Core.Entities.Task)_dbContext.Tasks.Where(t => t.Id == id);
            _dbContext.Tasks.Remove((Core.Entities.Task)task);
            return (Core.Entities.Task)task;
        }
    }
}
