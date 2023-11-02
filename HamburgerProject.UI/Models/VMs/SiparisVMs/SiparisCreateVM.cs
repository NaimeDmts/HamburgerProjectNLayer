using HamburgerProject.DATA.Enums;
using HamburgerProject.UI.Models.VMs.EkstraMalzemeVMs;
using HamburgerProject.UI.Models.VMs.MenuVMs;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace HamburgerProject.UI.Models.VMs.SiparisVMs
{
    public class SiparisCreateVM
    {
  
        [Display(Name = "Sipariş Boyutu: ")]
        [Required(ErrorMessage = "Sipariş Boyutu Boş Geçilemez")]
        public Boyut Boyut { get; set; }
        [Display(Name = "Siparis Adeti: ")]
        [Required(ErrorMessage = "Sipariş Adeti Boş Geçilemez")]
        public int Adet { get; set; }
        [Display(Name = "Müşteri Adı: ")]
        [Required(ErrorMessage = "Sipariş Kullanıcı Boş Geçilemez")]
        public string AppUserId { get; set; }

        [Display(Name = "Menuler: ")]
        [Required(ErrorMessage = "Sipariş Menu Boş Geçilemez")]
        public int MenuId { get; set; }
        public List<int> EkstraMalzemesIds { get; set; }
        public virtual ICollection<MenuVM> Menus { get; set; }
        [Display(Name = "Ekstra Malzemeler: ")]
        [Required(ErrorMessage = "Sipariş Ekstra Malzemeler Boş Geçilemez")]

        public virtual List<EkstraMalzemeVM> EkstraMalzemes { get; set; }
    }
}
