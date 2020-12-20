using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Entities;

namespace TaskManager.Core.RepositoryInterfaces
{
    public interface ITaskRepository : IAsyncRepository<Entities.Task>
    {
        //Should be able to Add/Update/Delete/List the users.
        Task<TaskManager.Core.Entities.Task> DeleteTaskById(int id);
    }
}
