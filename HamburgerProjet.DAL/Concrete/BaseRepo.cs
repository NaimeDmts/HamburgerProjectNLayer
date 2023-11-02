using HamburgerProjet.DAL.Abstractions;
using HamburgerProject.DATA.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HamburgerProjet.DAL.Contexts;
using HamburgerProject.DATA.Enums;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using HamburgerProject.DATA.Concrete;

namespace HamburgerProjet.DAL.Concrete
{
    public class BaseRepo<T> : IBaseRepo<T> where T : class, IBaseEntity
    {
        private readonly AppDbContext _context;

        public BaseRepo(AppDbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            if(entity != null)
            {

                _context.Set<T>().Add(entity);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Eklenecek Data Boş");
            }
        }

        public void Delete(T entity)
        {
            _context.SaveChanges();
        }

        public IList<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            if(id != 0)
            {
                return _context.Set<T>().Find(id);
            }
            else
            {
                throw new Exception("Id bulunmamaktadır.");
            }
        }

        public IList<T> GetDefaults(Expression<Func<T, bool>> expression)
        {
           return _context.Set<T>().Where(expression).ToList();
        }

        public IList<T> GetNotPassiveAll()
        {
            return _context.Set<T>().Where(x => x.Status != Status.Passive).ToList();
        }

        public void Update(T entity)
        {
            if (entity != null)
            {
                _context.Set<T>().Update(entity);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Güncellenecek Data Boş");
            }
        }
    }
}
