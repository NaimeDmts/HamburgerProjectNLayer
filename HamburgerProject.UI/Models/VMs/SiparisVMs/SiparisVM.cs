using HamburgerProject.BLL.DTOs.EkstraMalzemeDTOs;
using HamburgerProject.BLL.DTOs.MenuDTOs;
using HamburgerProject.BLL.DTOs.UserDTOs;
using HamburgerProject.DATA.Enums;
using HamburgerProject.UI.Models.VMs.EkstraMalzemeVMs;
using HamburgerProject.UI.Models.VMs.MenuVMs;
using HamburgerProject.UI.Models.VMs.UserVMs;

namespace HamburgerProject.UI.Models.VMs.SiparisVMs
{
    public class SiparisVM
    {
        public int Id { get; set; }
        public Boyut Boyut { get; set; }
        public int Adet { get; set; }
        public MenuVM Menu { get; set; }
        public UserVM AppUser { get; set; }
        // Navigation Properties
        public virtual ICollection<EkstraMalzemeVM> EkstraMalzemes { get; set; }
    }
}
