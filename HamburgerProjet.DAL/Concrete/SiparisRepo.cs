using HamburgerProject.DATA.Concrete;
using HamburgerProjet.DAL.Abstractions;
using HamburgerProjet.DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerProjet.DAL.Concrete
{
    public class SiparisRepo : BaseRepo<Siparis>,ISiparisRepo
    {
        private readonly AppDbContext _context;
        public SiparisRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public void AddSiparis(Siparis siparis)
        {
           
            _context.Siparis.Add(siparis);
            _context.SaveChanges();
        }
        public void UpdateSiparis(Siparis siparis)
        {
            if (siparis != null)
            {
                _context.Siparis.Update(siparis);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Güllenecek Data Boş");
            }
        }
    }
}
