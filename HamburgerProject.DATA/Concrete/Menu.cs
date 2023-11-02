using HamburgerProject.DATA.Abstractions;
using HamburgerProject.DATA.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerProject.DATA.Concrete
{
    [Table("TblMenu")]
    public class Menu : IBaseEntity
    {
        public Menu()
        {
            Siparisler = new HashSet<Siparis>();
        }
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
        public virtual ICollection<Siparis> Siparisler { get; set; }
    }
}
