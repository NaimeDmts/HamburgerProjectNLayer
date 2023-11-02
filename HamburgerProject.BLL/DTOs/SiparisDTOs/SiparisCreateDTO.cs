using HamburgerProject.BLL.DTOs.EkstraMalzemeDTOs;
using HamburgerProject.DATA.Concrete;
using HamburgerProject.DATA.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerProject.BLL.DTOs.SiparisDTOs
{
    public class SiparisCreateDTO
    {
       
        public Boyut Boyut { get; set; }
        public int Adet { get; set; }
        public string AppUserId { get; set; }
        public int MenuId { get; set; }
        // Navigation Properties
        public virtual List<EkstraMalzemeDTO> EkstraMalzemes { get; set; }

    }
}
