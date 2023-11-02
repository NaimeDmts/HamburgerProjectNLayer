using HamburgerProject.DATA.Abstractions;
using HamburgerProject.DATA.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerProject.DATA.Concrete
{
    public class SiparisMalzeme
    {
        public int Id { get; set; }
        public int SiparisId { get; set; }
        public int EkstraMalzemeId { get; set; }
        public virtual Siparis Siparis { get; set; }
        public virtual EkstraMalzeme EkstraMalzeme { get; set; }
    }
}
