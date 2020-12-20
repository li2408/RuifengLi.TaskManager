using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Entities;

namespace TaskManager.Core.RepositoryInterfaces
{
    public interface ITaskHistoryRepository: IAsyncRepository<TaskHistory>
    {
        Task<IEnumerable<TaskHistory>> GetTaskHistoriesById(int id);
    }
}
