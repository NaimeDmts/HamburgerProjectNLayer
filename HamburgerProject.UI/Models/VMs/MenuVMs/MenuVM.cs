using HamburgerProject.BLL.DTOs.SiparisDTOs;
using HamburgerProject.UI.Models.VMs.SiparisVMs;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace HamburgerProject.UI.Models.VMs.MenuVMs
{
    public class MenuVM
    {
        public int Id { get; set; }

        [Display(Name = "Menu Adı: ")]
        [Required(ErrorMessage = "Menu Adı Boş Geçilemez")]
        public string Name { get; set; }

        [Display(Name = "Menu Fiyatı: ")]
        [Required(ErrorMessage = "Menu Fiyatı Boş Geçilemez")]
        public double Price { get; set; }
        public virtual ICollection<SiparisVM> Siparisler { get; set; }
    }
}
