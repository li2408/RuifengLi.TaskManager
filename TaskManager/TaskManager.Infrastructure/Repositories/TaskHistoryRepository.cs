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
    public class TaskHistoryRepository : EfRepository<TaskHistory>, ITaskHistoryRepository
    {
        public TaskHistoryRepository(TaskManagerDbContext dbContext) : base(dbContext)
        {
        }
        
      
        public async Task<IEnumerable<TaskHistory>> GetTaskHistoriesById(int id)
        {
            var taskHistories = _dbContext.TaskHistories.Where(t => t.UserId == id);
            return taskHistories;
        }
    }
}
