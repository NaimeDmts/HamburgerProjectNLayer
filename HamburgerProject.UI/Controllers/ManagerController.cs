using AutoMapper;
using HamburgerProject.BLL.Abstractions;
using HamburgerProject.BLL.Concrete;
using HamburgerProject.BLL.DTOs.EkstraMalzemeDTOs;
using HamburgerProject.BLL.DTOs.MenuDTOs;
using HamburgerProject.BLL.DTOs.SiparisDTOs;
using HamburgerProject.BLL.DTOs.UserDTOs;
using HamburgerProject.DATA.Concrete;
using HamburgerProject.UI.Models.VMs.EkstraMalzemeVMs;
using HamburgerProject.UI.Models.VMs.MenuVMs;
using HamburgerProject.UI.Models.VMs.SiparisVMs;
using HamburgerProject.UI.Models.VMs.UserVMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HamburgerProject.UI.Controllers
{
    [Authorize(Roles ="Manager")]
    public class ManagerController : Controller
    {
        private readonly IUserService _userService;
        private readonly IEkstraMalzemeService _ekstraMalzemeService;
        private readonly IMenuService _menuService;
        private readonly IMapper _mapper;

        public ManagerController(IUserService userService, IEkstraMalzemeService ekstraMalzemeService, IMenuService menuservice, IMapper mapper)
        {
            _userService = userService;
            _ekstraMalzemeService = ekstraMalzemeService;
            _menuService = menuservice;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
        
           
            return View();
        }
       
        [HttpGet]
        public IActionResult EkstraMalzemeListesi()
        {
            IList<EkstraMalzemeDTO> ekstraMalzemeDTOs = _ekstraMalzemeService.GetNotPassiveAll();
            IList<EkstraMalzemeVM> ekstraMalzemeVMs = _mapper.Map<IList<EkstraMalzemeDTO>, IList<EkstraMalzemeVM>>(ekstraMalzemeDTOs);
            return View(ekstraMalzemeVMs);
        }
        [HttpGet]
        public IActionResult EkstraMalzemeAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EkstraMalzemeAdd(EkstraMalzemeCreateVM ekstraMalzemeCreateVM)
        {
            if (ModelState.IsValid)
            {
                EkstraMalzemeCreateDTO ekstraMalzemeDTO = _mapper.Map<EkstraMalzemeCreateDTO>(ekstraMalzemeCreateVM);
                _ekstraMalzemeService.AddEkstraMalzeme(ekstraMalzemeDTO);
                return RedirectToAction("EkstraMalzemeListesi");

            }

            return View(ekstraMalzemeCreateVM);
        }
        [HttpGet]
        public IActionResult EkstraMalzemeEdit(int id)
        {
            EkstraMalzemeDTO ekstraMalzemeDTO = _ekstraMalzemeService.GetByIdEkstraMalzeme(id);
            var ekstraMalzemeEditVM = _mapper.Map<EkstraMalzemeUpdateVM>(ekstraMalzemeDTO);
            return View(ekstraMalzemeEditVM);
        }
        [HttpPost]
        public IActionResult EkstraMalzemeEdit(EkstraMalzemeUpdateVM ekstraMalzemeUpdateVM)
        {
            if (ModelState.IsValid)
            {
                EkstraMalzemeUpdateDTO ekstraMalzemeDTO = _mapper.Map<EkstraMalzemeUpdateDTO>(ekstraMalzemeUpdateVM);
                _ekstraMalzemeService.UpdateEkstraMalzeme(ekstraMalzemeDTO);
                return RedirectToAction("EkstraMalzemeListesi");
            }
            return View(ekstraMalzemeUpdateVM);
        }
        [HttpGet]
        public IActionResult EkstraMalzemeDelete(int id)
        {
            _ekstraMalzemeService.DeleteEkstraMalzeme(id);
            return RedirectToAction("EkstraMalzemeListesi");
        }
        [HttpGet]
        public IActionResult MenuListesi()
        {
            IList<MenuDTO> menuDTOs = _menuService.GetNotPassiveAll();
            IList<MenuVM> menuVMs = _mapper.Map<IList<MenuDTO>, IList<MenuVM>>(menuDTOs);
            return View(menuVMs);
        }
        [HttpGet]
        public IActionResult MenuAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MenuAdd(MenuCreateVM menuCreateVM)
        {
            if (ModelState.IsValid)
            {
                var menuCreateDTO = _mapper.Map<MenuCreateDTO>(menuCreateVM);
                _menuService.AddMenu(menuCreateDTO);
                return RedirectToAction("MenuListesi");

            }

            return View(menuCreateVM);
        }
        [HttpGet]
        public IActionResult MenuEdit(int id)
        {
            var menuDTO = _menuService.GetByIdMenu(id);
            var menuEditVM = _mapper.Map<MenuUpdateVM>(menuDTO);
            return View(menuEditVM);
        }
        [HttpPost]
        public IActionResult MenuEdit(MenuUpdateVM menuUpdateVM)
        {
            if (ModelState.IsValid)
            {
                MenuUpdateDTO menuDTO = _mapper.Map<MenuUpdateDTO>(menuUpdateVM);
                _menuService.UpdateMenu(menuDTO);
                return RedirectToAction("MenuListesi");
            }
            return View(menuUpdateVM);
        }
        [HttpGet]
        public IActionResult MenuDelete(int id)
        {
            _menuService.DeleteMenu(id);
            return RedirectToAction("MenuListesi");
        }
    }
}