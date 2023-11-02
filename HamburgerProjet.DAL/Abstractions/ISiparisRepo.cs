using HamburgerProject.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerProjet.DAL.Abstractions
{
    public interface ISiparisRepo :IBaseRepo<Siparis>
    {
        void AddSiparis(Siparis siparis);
        void UpdateSiparis(Siparis siparis);
    }
}
