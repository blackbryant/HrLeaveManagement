using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrLeaveManagement.Application.IRepository
{
    public interface IGenericRepositoryAsync<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAll();

        Task<T> GetById(int id);

        Task Add(T entity);

        Task Update(T entity);

        Task Delete(T entity);

       


    }
}
