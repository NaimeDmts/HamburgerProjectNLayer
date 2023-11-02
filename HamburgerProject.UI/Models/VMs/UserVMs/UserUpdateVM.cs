using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HamburgerProject.BLL.DTOs.UserDTOs
{
    public class UserUpdateVM
    {
        public string Id { get; set; }

        [Display(Name = "Kullanıcı Adı: ")]
        [Required(ErrorMessage = "Kullanıcı Adı Boş Geçilemez")]
        public string UserName { get; set; }
        [Display(Name = "Ad: ")]
        [Required(ErrorMessage = "Ad Boş Geçilemez")]
        public string FirstName { get; set; }
        [Display(Name = "Soyad: ")]
        [Required(ErrorMessage = "Soyad Boş Geçilemez")]

        public string LastName { get; set; }

        [Display(Name = "Email: ")]
        [Required(ErrorMessage = "Mail Boş Geçilemez")]
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name = "Telefon: ")]
        [Required(ErrorMessage = "Telefon Boş Geçilemez")]
        [Phone]
        public string PhoneNumber { get; set; }
    }
}
