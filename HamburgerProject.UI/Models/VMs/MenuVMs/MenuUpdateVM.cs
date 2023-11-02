using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace HamburgerProject.UI.Models.VMs.MenuVMs
{
    public class MenuUpdateVM
    {
        public int Id { get; set; }
        [Display(Name = "Menu Adı: ")]
        [Required(ErrorMessage = "Menu Adı Boş Geçilemez")]
        public string Name { get; set; }

        [Display(Name = "Menu Fiyatı: ")]
        [Required(ErrorMessage = "Menu Fiyatı Boş Geçilemez")]
        public double Price { get; set; }
    }
}
