using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HamburgerProject.DATA.Enums
{
    public enum Boyut
    {
        [Display(Name = "Küçük")]
        Kucuk =1,
        [Display(Name = "Orta")]
        Orta,
        [Display(Name = "Büyük")]
        Buyuk
    }
}
