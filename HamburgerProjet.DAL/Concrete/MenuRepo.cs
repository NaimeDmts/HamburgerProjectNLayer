using HamburgerProject.DATA.Concrete;
using HamburgerProjet.DAL.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerProjet.DAL.Concrete
{
    public class MenuRepo : BaseRepo<Menu>
    {
        public MenuRepo(AppDbContext context) : base(context)
        {
        }
    }
}
