using HamburgerProject.BLL.DTOs.SiparisDTOs;
using HamburgerProject.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerProject.BLL.DTOs.MenuDTOs
{
    public class MenuDTO
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public virtual  ICollection<SiparisDTO> Siparisler { get; set; }
    }
}
