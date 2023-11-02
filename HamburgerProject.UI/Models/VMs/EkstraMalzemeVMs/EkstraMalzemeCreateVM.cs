using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace HamburgerProject.UI.Models.VMs.EkstraMalzemeVMs
{
    public class EkstraMalzemeCreateVM
    {
        [Display(Name = "Malzeme Adı: ")]
        [Required(ErrorMessage = "Malzeme Adı Boş Geçilemez")]
        public string Name { get; set; }
        [Display(Name = "Malzeme Fiyatı: ")]
        [Required(ErrorMessage = "Malzeme Fiyatı Boş Geçilemez")]
        public double Price { get; set; }
    }
}
