using HamburgerProject.DATA.Concrete;
using HamburgerProjet.DAL.Abstractions;
using HamburgerProjet.DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerProjet.DAL.Concrete
{
    public class SiparisMalzemeRepo :ISiparisMalzemeRepo
    {
        private readonly AppDbContext _context;
        public SiparisMalzemeRepo(AppDbContext context)
        {
            _context = context;

        }

        public IList<SiparisMalzeme> GetDefaults(Expression<Func<SiparisMalzeme, bool>> expression)
        {
            return _context.SiparisMalzemes.Where(expression).ToList();
        }
        public void Update(SiparisMalzeme siparisMalzeme)
        {
            if (siparisMalzeme != null)
            {
                _context.SiparisMalzemes.Update(siparisMalzeme);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Güncellenecek Data Boş");
            }
        }
        public void Delete(SiparisMalzeme siparisMalzeme)
        {
            if (siparisMalzeme != null)
            {
                _context.SiparisMalzemes.Remove(siparisMalzeme);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("silmek istenen Data Boş");
            }
        }

        public void Add(SiparisMalzeme siparisMalzeme)
        {
            _context.SiparisMalzemes.Add(siparisMalzeme);
            _context.SaveChanges();
        }
    }
}
