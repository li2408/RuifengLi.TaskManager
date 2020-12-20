using TaskManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Entities;

namespace TaskManager.Core.RepositoryInterfaces
{
    public interface IUserRepository : IAsyncRepository<User>
    {
        //Should be able to Add/Update/Delete/List the users.
        Task<User> GetUserByEmail(string email);

    }
}
