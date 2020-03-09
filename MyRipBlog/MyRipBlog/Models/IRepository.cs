using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRipBlog.Models
{
    public interface IRepository<T> : IDisposable
        where T:class
    {
        IEnumerable<T> GetAll();
        Task<T> GetById(int id);
        Task<T> GetByEmail(string email);
        Task<T> GetByUsername(string username);

        Task Create(T entity);
        Task Update(int id, T entity);
        Task Delete(int id);
    }
}
