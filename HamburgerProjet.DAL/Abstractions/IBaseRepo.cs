using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using HamburgerProject.DATA.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerProjet.DAL.Abstractions
{
    public interface IBaseRepo<T> where T : class, IBaseEntity
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T GetById (int id);
        IList<T> GetAll();
        IList<T> GetNotPassiveAll();
        IList<T> GetDefaults(Expression<Func<T, bool>> expression);

    }
}
