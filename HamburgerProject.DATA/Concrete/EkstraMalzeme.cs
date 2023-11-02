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
    [Table("TblSauce")]
    public class EkstraMalzeme : IBaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        public DateTime CreatDate { get; set; } = DateTime.Now;
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Status Status { get; set; } = Status.Active;

        //Navigation Properties
        public virtual List<SiparisMalzeme> SiparisMalzemes{ get; set; }
    }
}
