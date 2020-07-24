using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityProject.Services
{
    public interface IGenericRepository<T> where T : class
    {
        Task<ICollection<T>> GetAll();
        Task<T> GetById(object id);
        void Insert(T obj);
        void Update(T obj);
        Task DeleteAsync(object id);
        Task SaveAsync();
    }
}
