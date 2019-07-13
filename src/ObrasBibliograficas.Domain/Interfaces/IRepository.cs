using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ObrasBibliograficas.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity<TEntity>
    {
        IEnumerable<TEntity> GetAll();

        TEntity Add(TEntity obj);
        IEnumerable<TEntity> Add(IEnumerable<TEntity> obj);
        TEntity GetById(int id);
        void Update(TEntity obj);
        void Delete(int id);
        IEnumerable<TEntity> GetByFunc(Expression<Func<TEntity, bool>> predicate);
        int SaveChanges();
    }
}
