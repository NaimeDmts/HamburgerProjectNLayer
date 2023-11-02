using HamburgerProject.DATA.Concrete;
using HamburgerProject.DATA.Enums;
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
    public class EkstraMalzemeRepo : BaseRepo<EkstraMalzeme>,IEkstraMalzemeRepo
    {
        private readonly AppDbContext _context;
        public EkstraMalzemeRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public EkstraMalzeme GetDefaultsEM(int id)
        {
            return _context.EkstraMalzemes.AsNoTracking().FirstOrDefault(x => x.Id == id && x.Status != Status.Passive);
        }
    }
}
