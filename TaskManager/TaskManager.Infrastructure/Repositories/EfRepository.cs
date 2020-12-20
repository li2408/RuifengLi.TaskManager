using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManager.Core.RepositoryInterfaces;
using TaskManager.Infrastructure.Data;

namespace TaskManager.Infrastructure.Repositories
{
    public class EfRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly TaskManagerDbContext _dbContext;
        public EfRepository(TaskManagerDbContext dbContext)
        {
            _dbContext = dbContext; //initialize our dbContext.
        }
        public virtual async Task<T> GetByIdAsync(int id)
        {
            //FindAsync: Finds an entity with the given primary key values
            var entity = await _dbContext.Set<T>().FindAsync(id);
            return entity;
        }


        public async Task<IEnumerable<T>> ListAllAsync()
        {
            var tasks = await _dbContext.Set<T>().ToListAsync();
            Console.WriteLine(tasks);
            return tasks;
        }
        public async Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> filter)
        {
            return await _dbContext.Set<T>().Where(filter).ToListAsync();
        }
        public async Task<int> GetCountAsync(Expression<Func<T, bool>> filter = null)
        {
            if (filter != null)
            {
                return await _dbContext.Set<T>().Where(filter).CountAsync();
            }
            return await _dbContext.Set<T>().CountAsync();//if there's no condition, the just return all.
        }
        public async Task<bool> GetExistsAsync(Expression<Func<T, bool>> filter = null)
        {
            if (filter != null && await _dbContext.Set<T>().Where(filter).AnyAsync())
                return true;
            return false;
        }
        public virtual async Task<T> AddAsync(T entity)
        {
            //this is the disconnected way: using stateless protocol. 
            //just tell EF we want to update the entity.
            _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        public async Task<T> UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> ListAllWithIncludesAsync(Expression<Func<T, bool>> @where, params Expression<Func<T, object>>[] includes)
        {
            var query = _dbContext.Set<T>().AsQueryable();


            if (includes != null)
                foreach (Expression<Func<T, object>> navigationProperty in includes)
                    query = query.Include(navigationProperty);


            return await query.Where(@where).ToListAsync();
        }
    }


}