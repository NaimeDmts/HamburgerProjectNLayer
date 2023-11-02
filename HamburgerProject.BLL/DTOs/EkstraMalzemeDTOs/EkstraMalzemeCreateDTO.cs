using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerProject.BLL.DTOs.EkstraMalzemeDTOs
{
    public class EkstraMalzemeCreateDTO
    {
  
        public string Name { get; set; }
     
        public double Price { get; set; }
    }
}
