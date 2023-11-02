using AutoMapper;
using HamburgerProject.BLL.Abstractions;
using HamburgerProject.BLL.DTOs.EkstraMalzemeDTOs;
using HamburgerProject.BLL.DTOs.MenuDTOs;
using HamburgerProject.BLL.DTOs.SiparisDTOs;
using HamburgerProject.BLL.DTOs.UserDTOs;
using HamburgerProject.UI.Models.VMs.EkstraMalzemeVMs;
using HamburgerProject.UI.Models.VMs.MenuVMs;
using HamburgerProject.UI.Models.VMs.SiparisVMs;
using HamburgerProject.UI.Models.VMs.UserVMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Security.Claims;

namespace HamburgerProject.UI.Controllers
{
    [Authorize(Roles = "Member")]
    public class MemberController : Controller
    {
        private readonly ISiparisService _siparisService;
        private readonly IMenuService _menuService;
        private readonly IEkstraMalzemeService _ekstraMalzemeService;
        private readonly IMapper _mapper;

        public MemberController(ISiparisService siparisService, IMenuService menuService, IEkstraMalzemeService ekstraMalzemeService, IMapper mapper)
        {
            _siparisService = siparisService;
            _menuService = menuService;
            _ekstraMalzemeService = ekstraMalzemeService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Index()
        {
            IList<SiparisDTO> siparisDTO = _siparisService.GetNotPassiveAll();
            IList<SiparisVM> siparisVM = _mapper.Map<IList<SiparisDTO>, IList<SiparisVM>>(siparisDTO.ToList());
          
            return View(siparisVM);

        }
        [HttpGet]
        public IActionResult SiparisAdd()
        {
            IList<MenuDTO> menuDTOs = _menuService.GetNotPassiveAll();
            IList<MenuVM> menuVMs = _mapper.Map<IList<MenuDTO>, IList<MenuVM>>(menuDTOs);
            List<EkstraMalzemeDTO> emDTOs = _ekstraMalzemeService.GetNotPassiveAll().ToList();
            List<EkstraMalzemeVM> emVMs = _mapper.Map<List<EkstraMalzemeDTO>, List<EkstraMalzemeVM>>(emDTOs);
            SiparisCreateVM vm = new SiparisCreateVM();
            vm.Menus = menuVMs;
            vm.EkstraMalzemes = emVMs;
            return View(vm);
        }
        [HttpPost]
        public IActionResult SiparisAdd(SiparisCreateVM siparisCreateVM,IList<int> EkstraMalzemeIds)
        {
            IList<EkstraMalzemeVM> ekstraMalzemeler = new List<EkstraMalzemeVM>();
            foreach (var em in EkstraMalzemeIds)
                {
                var dto = _ekstraMalzemeService.GetDefaultsEM(em);

                if (dto != null)
                {
                    var vm = _mapper.Map<EkstraMalzemeVM>(dto);
                    ekstraMalzemeler.Add(vm);
                }
            }       
                siparisCreateVM.AppUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                siparisCreateVM.EkstraMalzemes = ekstraMalzemeler.ToList();
                SiparisCreateDTO siparisDTO = _mapper.Map<SiparisCreateDTO>(siparisCreateVM);
                _siparisService.AddSiparis(siparisDTO);
                return RedirectToAction("Index");
           
     
           
        }
        [HttpGet]
        public IActionResult SiparisEdit(int id)
        {
            var siparisDTO = _siparisService.GetByIdSiparis(id);
            var siparisEditVM = _mapper.Map<SiparisUpdateVM>(siparisDTO);
            siparisEditVM.Menus = _mapper.Map<IList<MenuDTO>,IList<MenuVM>>( _menuService.GetNotPassiveAll());
            siparisEditVM.EkstraMalzemes = _mapper.Map<List<EkstraMalzemeDTO>, List<EkstraMalzemeVM>>(_ekstraMalzemeService.GetNotPassiveAll().ToList());
            return View(siparisEditVM);
        }
        [HttpPost]
        public IActionResult SiparisEdit(SiparisUpdateVM siparisUpdateVM, List<int> EkstraMalzemesId)
        {
            List<EkstraMalzemeVM> ekstraMalzemeler = new List<EkstraMalzemeVM>();
            foreach (var em in EkstraMalzemesId)
            {
                var dto = _ekstraMalzemeService.GetDefaultsEM(em);

                if (dto != null)
                {
                    var vm = _mapper.Map<EkstraMalzemeVM>(dto);
                    ekstraMalzemeler.Add(vm);
                }

            }

                     SiparisUpdateDTO updateDTO = _mapper.Map<SiparisUpdateDTO>(siparisUpdateVM);
                    updateDTO.EkstraMalzemes = _mapper.Map<List<EkstraMalzemeDTO>>(ekstraMalzemeler);

                    _siparisService.UpdateSiparis(updateDTO);
                    return RedirectToAction("Index");
              
            
        }
        [HttpGet]
        public IActionResult SiparisDelete(int id)
        {
            _siparisService.DeleteSiparis(id);
            return RedirectToAction("Index");
        }
    }
}
