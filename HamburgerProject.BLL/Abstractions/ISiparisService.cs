using HamburgerProject.BLL.DTOs.SiparisDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerProject.BLL.Abstractions
{
    public interface ISiparisService
    {
        void AddSiparis(SiparisCreateDTO createDTO);
        void DeleteSiparis(int id);
        void UpdateSiparis(SiparisUpdateDTO updateDTO);
        SiparisDTO GetByIdSiparis(int Id);

        IList<SiparisDTO> GetAll();
        IList<SiparisDTO> GetNotPassiveAll();
    }
}
