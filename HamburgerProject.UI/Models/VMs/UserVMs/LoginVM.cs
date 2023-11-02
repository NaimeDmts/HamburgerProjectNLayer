using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace HamburgerProject.UI.Models.VMs.UserVMs
{
    public class LoginVM
    {

        [Display(Name = "Kullanıcı Adı: ")]
        [Required(ErrorMessage = "Kullanıcı Adı Boş Geçilemez")]
        public string UserName { get; set; }

        [Display(Name = "Şifre: ")]
        [Required(ErrorMessage = "Şifre Boş Geçilemez")]
        [DataType(DataType.Password)]
        [StringLength(10, ErrorMessage = "Max 10 min 3 olmalı", MinimumLength = 3)]
        public string Password { get; set; }
    }
}
