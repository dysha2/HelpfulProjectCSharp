using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpfulProjectCSharp.ASP
{
    public interface ICrudRep
    {
        public bool Create<TEntity>(TEntity entity) where TEntity : class;
        public bool Create<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
        public TEntity Read<TEntity>(int id) where TEntity : class;
        public List<TEntity> Read<TEntity>() where TEntity : class;
        public bool Update<TEntity>(TEntity entity) where TEntity : class;
        public bool Update<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
        public bool Delete<TEntity>(TEntity entity) where TEntity : class;
        public bool Delete<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
    }
}
