using HamburgerProject.DATA.Abstractions;
using HamburgerProject.DATA.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerProject.DATA.Concrete
{
    [Table("TblOrder")]
    public class Siparis : IBaseEntity
    {

        public int Id { get; set; }
        public DateTime CreatDate { get; set; } = DateTime.Now;
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Status Status { get; set; } = Status.Active;
        public Boyut Boyut { get; set; }
        [Required]
        public int Adet { get; set; }   
        public string? AppUserId { get; set; }
        public int MenuId { get; set; }
        // Navigation Properties
        public virtual AppUser AppUser { get; set; }    
        public virtual Menu Menu { get; set; }
        public virtual ICollection<SiparisMalzeme> SiparisMalzemes { get; set; }  
    }
}
