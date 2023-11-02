using AutoMapper;
using HamburgerProject.BLL.Abstractions;
using HamburgerProject.BLL.DTOs.MenuDTOs;
using HamburgerProject.BLL.DTOs.SiparisDTOs;
using HamburgerProject.DATA.Concrete;
using HamburgerProject.DATA.Enums;
using HamburgerProjet.DAL.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerProject.BLL.Concrete
{
    public class MenuService : IMenuService
    {
        private readonly IBaseRepo<Menu> _repo;
        private readonly IMapper _mapper;


        public MenuService(IBaseRepo<Menu> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public void AddMenu(MenuCreateDTO createDTO)
        {
            var menu = _mapper.Map<Menu>(createDTO);
            _repo.Add(menu);
        }

        public void DeleteMenu(int Id)
        {
            var menu = _repo.GetById(Id);
            menu.Status = Status.Passive;
            menu.DeleteDate = DateTime.Now;
            _repo.Delete(menu);
        }

        public IList<MenuDTO> GetAll()
        {
            IList<Menu> menuler = _repo.GetAll();
            IList<MenuDTO> menuDTOs = _mapper.Map<IList<Menu>,IList<MenuDTO>>(menuler);
            return menuDTOs;
        }

        public MenuDTO GetByIdMenu(int Id)
        {
            var menu = _repo.GetById(Id);
            MenuDTO menuDTO= _mapper.Map<MenuDTO>(menu);
            return menuDTO;
        }

        public IList<MenuDTO> GetNotPassiveAll()
        {

            IList<Menu> menuler = _repo.GetNotPassiveAll();
            IList<MenuDTO> menulerDTO = _mapper.Map<IList<Menu>, IList<MenuDTO>>(menuler);
            return menulerDTO;
        }

        public void UpdateMenu(MenuUpdateDTO updateDTO)
        {
           var menu = _mapper.Map<Menu>(updateDTO);
            menu.UpdateDate = DateTime.Now;
            menu.Status = Status.Modified;
            _repo.Update(menu);
        }
    }
}
