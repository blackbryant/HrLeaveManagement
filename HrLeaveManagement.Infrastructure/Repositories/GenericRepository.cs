using HrLeaveManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;
using HrLeaveManagement.Application.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrLeaveManagement.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepositoryAsync<T> where T : class
    {
        private readonly HrLeaveContext _dbContext;

        public GenericRepository(HrLeaveContext dbContext)
        {
            _dbContext = dbContext;
        }
         
        public async Task Add(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
           
        }

        public async Task Delete(T entity)
        {
             _dbContext.Set<T>().Remove(entity);
            await  _dbContext.SaveChangesAsync();
        }

        public async  Task<bool> Exists(int id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);
            return entity != null;
        }

        public async Task<T> GetById(int id)
        {
            return await  _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
          var entities = await _dbContext.Set<T>().ToListAsync();
            return entities;
        }

        public async Task Update(T entity)
        {
            var entityEntry = _dbContext.Entry(entity);

            if (entityEntry.State == EntityState.Detached)
            {
                _dbContext.Set<T>().Attach(entity);
            }

            entityEntry.State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();
        }
    }
}
