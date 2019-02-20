using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Wissen.Model;

namespace Wissen.Data
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext db;
        private readonly DbSet<T> entities;

        public Repository(ApplicationDbContext context)
        {
            this.db = context;
            this.entities = db.Set<T>();
        }

        public void Delete(T entity)
        {
            entities.Remove(entity);
            db.SaveChanges();
        }

        public T Find(int id)
        {
            return entities.FirstOrDefault(f => f.Id == id);
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return entities.FirstOrDefault(where);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> where)
        {
            return entities.Where(where).ToList();
        }

        public void Insert(T entity)
        {
            entity.CreatedAt = DateTime.Now;
            entity.CreatedBy = "username";
            entity.UpdatedAt = DateTime.Now;
            entity.UpdatedBy = "username";
            entities.Add(entity);
            db.SaveChanges();
        }

        public void Update(T entity)
        {
            entity.UpdatedAt = DateTime.Now;
            entity.UpdatedBy = "username";
            db.Entry<T>(entity).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
