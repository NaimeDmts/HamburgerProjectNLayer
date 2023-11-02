using HamburgerProject.DATA.Abstractions;
using HamburgerProject.DATA.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerProject.DATA.Concrete
{
    [Table("TblUser")]
    public class AppUser : IdentityUser, IBaseEntity
    {
        public AppUser()
        {
            Siparisler = new HashSet<Siparis>();
        }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; }
        public DateTime CreatDate { get; set; } = DateTime.Now;
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Status Status { get; set; } = Status.Active;

        //Navigation Properties
        public virtual ICollection<Siparis> Siparisler { get; set; }
    }
}
