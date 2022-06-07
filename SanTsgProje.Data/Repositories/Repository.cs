using SanTsgProje.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SanTsgProje.Data.Repositories
{
    //Repository Generic for all repository patterns
    public class Repository<T> : IRepository<T> where T : class
    {
        private protected readonly ProjeDbContext _context;
        public Repository(ProjeDbContext context)
        {
            _context = context;
        }
        //Get with Id method
        public T Get(int? id)
        {
            return _context.Set<T>().Find(id);
        }
        //Get all in class method
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        //Add method
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        //Add range method
        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        //Find method
        public IEnumerable<T> Find(Expression<Func<T, bool>> filter)
        {
            return _context.Set<T>().Where(filter);
        }

        //Remove method
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        //Remove range method
        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        //Update method
        public void Update (T entity)
        {
            _context.Set<T>().Update(entity);
        }

        //Save method
        public void Save(T entity)
        {
            _context.SaveChanges();
        }
    }
}
