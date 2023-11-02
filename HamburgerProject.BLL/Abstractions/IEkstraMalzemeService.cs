using HamburgerProject.BLL.DTOs.EkstraMalzemeDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerProject.BLL.Abstractions
{
    public interface IEkstraMalzemeService
    {
        void AddEkstraMalzeme(EkstraMalzemeCreateDTO createDTO);
        void DeleteEkstraMalzeme(int id);
        void UpdateEkstraMalzeme(EkstraMalzemeUpdateDTO updateDTO);
        EkstraMalzemeDTO GetByIdEkstraMalzeme(int Id);
        EkstraMalzemeUpdateDTO GetDefaultsEM(int Id);


        IList<EkstraMalzemeDTO> GetAll();
        IList<EkstraMalzemeDTO> GetNotPassiveAll();
    }
}
