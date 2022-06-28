using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();


        //IMPLEMENTAR OS SPECS DEPOIS

        // This is for tracking in memory in EF. Hence, kept synchronous.
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
