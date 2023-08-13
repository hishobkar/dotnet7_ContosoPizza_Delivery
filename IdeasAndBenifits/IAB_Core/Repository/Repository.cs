using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAB_Core.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private ApplicationDbContext _context;
        DbSet<T> _entity = null;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }

        public bool Add(T entity)
        {
            try
            {
                _entity.Add(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(T entity)
        {
            try
            {
                _entity.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<T> GetAll()
        {
            return _entity.ToList();
        }

        public T GetById(int id)
        {
            return _entity.Find(id);
        }

        public bool Update(T entity)
        {
            try
            {
                _entity.Update(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
