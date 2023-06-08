using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpfulProjectCSharp.ASP
{
    public class CrudRep<Context> :ICrudRep where Context : DbContext
    {
        private Context _context { get; }

        public CrudRep(Context context)
        {
            _context = context;
        }
        public bool Update<TEntity>(TEntity entity) where TEntity : class
        {
            if (entity is not null)
            {
                var DbSet = _context.Set<TEntity>();
                DbSet.Update(entity);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Delete<TEntity>(TEntity entity) where TEntity : class
        {
            if (entity is not null)
            {
                var DbSet = _context.Set<TEntity>();
                DbSet.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public List<TEntity> Read<TEntity>() where TEntity : class
        {
            return _context.Set<TEntity>().ToList();
        }
        public TEntity Read<TEntity>(int id) where TEntity : class
        {
            return _context.Set<TEntity>().Find(id);
        }
        public TEntity Create<TEntity>(TEntity entity) where TEntity : class
        {
            if (entity is not null)
            {
                var DbSet = _context.Set<TEntity>();
                DbSet.Add(entity);
                _context.SaveChanges();
                return entity;
            }
            return null;
        }
        public bool Create<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            if ((entities is not null) && (entities.Count() > 0))
            {
                var DbSet = _context.Set<TEntity>();
                DbSet.AddRange(entities);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Update<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            if ((entities is not null) && (entities.Count() > 0))
            {
                var DbSet = _context.Set<TEntity>();
                DbSet.UpdateRange(entities);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Delete<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            if ((entities is not null) && (entities.Count() > 0))
            {
                var DbSet = _context.Set<TEntity>();
                DbSet.RemoveRange(entities);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
