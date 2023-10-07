using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    // Generic Constraint
    //class: referans tip olabilir demektir.
    //IEntity: T ya IEntity olabilir veya IEntity implemente eden bir nesne olabilir.
    //new(); new'lenebilir olmalıdır. Interface'leri elemektedir.
    public interface IEntityRepository<T> where T: class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
