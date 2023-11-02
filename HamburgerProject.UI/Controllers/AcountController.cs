using AutoMapper;
using HamburgerProject.BLL.Abstractions;
using HamburgerProject.BLL.DTOs.UserDTOs;
using HamburgerProject.DATA.Concrete;
using HamburgerProject.UI.Models.VMs.UserVMs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HamburgerProject.UI.Controllers
{
    public class AcountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AcountController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserCreateVM userCreateVM)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<UserCreateDTO>(userCreateVM);
                IdentityResult result = await _userService.AddUser(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description.ToString());
                    }
                }
            }
            return View();

        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            var loginDTO = _mapper.Map<LoginDTO>(loginVM);
            bool user = await _userService.Login(loginDTO);
            if(user)
            {
                return RedirectToAction("Index","Manager");
            }
            else
            {
                return RedirectToAction("Index", "Member");
            }
        }
        public async Task<IActionResult> LogOut()
        {
            await _userService.LogOut();
            return RedirectToAction("Index","Home");

        }
    }
}
