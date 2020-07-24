using CharityProject.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CharityProject.Services
{
    public class GenericRepository<T> : IGenericRepository<T> where T:class
    {
        private CharityDBContext _context = null;
        private DbSet<T> table = null;

   

        public GenericRepository()
        {
            this._context = new CharityDBContext();
            table = _context.Set<T>();
        }
        public GenericRepository(CharityDBContext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }
      

        public async Task<ICollection<T>> GetAll()
        {
            return await table.ToListAsync();
        }
  

        public async Task<T> GetById(object id)
        {
            return await table.FindAsync(id);
        }

        public void Insert(T obj)
        {
            table.Add(obj);
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        public async Task DeleteAsync(object id)
        {
            T existing =await table.FindAsync(id);
            table.Remove(existing);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }



    }



 
}
