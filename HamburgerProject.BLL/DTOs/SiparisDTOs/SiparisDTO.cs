using HamburgerProject.BLL.DTOs.EkstraMalzemeDTOs;
using HamburgerProject.BLL.DTOs.MenuDTOs;
using HamburgerProject.BLL.DTOs.UserDTOs;
using HamburgerProject.DATA.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerProject.BLL.DTOs.SiparisDTOs
{
    public class SiparisDTO
    {
        public int Id { get; set; }
        public Boyut Boyut { get; set; }
        public int Adet { get; set; }

        public MenuDTO Menu { get; set; }
        public UserDTO AppUser { get; set; }
        // Navigation Properties
        public virtual ICollection<EkstraMalzemeDTO> EkstraMalzemes { get; set; }
    }
}
