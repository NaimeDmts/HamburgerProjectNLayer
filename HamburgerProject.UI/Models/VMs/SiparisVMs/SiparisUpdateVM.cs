using HamburgerProject.BLL.DTOs.EkstraMalzemeDTOs;
using HamburgerProject.DATA.Enums;
using HamburgerProject.UI.Models.VMs.EkstraMalzemeVMs;
using HamburgerProject.UI.Models.VMs.MenuVMs;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace HamburgerProject.UI.Models.VMs.SiparisVMs
{
    public class SiparisUpdateVM
    {
        public SiparisUpdateVM()
        {
            EkstraMalzemes = new List<EkstraMalzemeVM>();
        }
        public int Id { get; set; }
        [Display(Name = "Sipariş Boyutu: ")]
        [Required(ErrorMessage = "Sipariş Boyutu Boş Geçilemez")]
        public Boyut Boyut { get; set; }
        [Display(Name = "Siparis Adeti: ")]
        [Required(ErrorMessage = "Sipariş Adeti Boş Geçilemez")]
        public int Adet { get; set; }
        [Display(Name = "Müşteri Adı: ")]
        [Required(ErrorMessage = "Sipariş Kullanıcısı Boş Geçilemez")]
        public string AppUserId { get; set; }

        [Display(Name = "Menuler: ")]
        [Required(ErrorMessage = "Sipariş Menu Boş Geçilemez")]
        public int MenuId { get; set; }
        public List<int> EkstraMalzemesId { get; set; }
        public virtual ICollection<MenuVM> Menus { get; set; }
        // Navigation Properties
        public virtual List<EkstraMalzemeVM> EkstraMalzemes { get; set; }
    }
}
