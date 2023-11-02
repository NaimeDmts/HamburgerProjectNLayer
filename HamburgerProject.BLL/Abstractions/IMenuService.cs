using HamburgerProject.BLL.DTOs.MenuDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerProject.BLL.Abstractions
{
    public interface IMenuService
    {
        void AddMenu(MenuCreateDTO createDTO);
        void DeleteMenu(int Id);
        void UpdateMenu(MenuUpdateDTO updateDTO);
        MenuDTO GetByIdMenu(int Id);

        IList<MenuDTO> GetAll();
        IList<MenuDTO> GetNotPassiveAll();
    }
}
