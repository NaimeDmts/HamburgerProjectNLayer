using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HamburgerProject.DATA.Concrete;
using HamburgerProject.BLL.DTOs.SiparisDTOs;

namespace HamburgerProject.BLL.DTOs.EkstraMalzemeDTOs
{
    public class EkstraMalzemeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
