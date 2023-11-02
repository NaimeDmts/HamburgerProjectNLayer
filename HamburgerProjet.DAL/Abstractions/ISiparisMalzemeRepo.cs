using HamburgerProject.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerProjet.DAL.Abstractions
{
    public interface ISiparisMalzemeRepo
    {
        public void Add(SiparisMalzeme siparisMalzeme);
        IList<SiparisMalzeme> GetDefaults(Expression<Func<SiparisMalzeme,bool>> expression);
        public void Update(SiparisMalzeme siparisMalzeme);
        public void Delete(SiparisMalzeme siparisMalzeme);

    }
}
