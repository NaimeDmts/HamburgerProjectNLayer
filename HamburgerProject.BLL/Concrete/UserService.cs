using AutoMapper;
using HamburgerProject.BLL.Abstractions;
using HamburgerProject.BLL.DTOs.SiparisDTOs;
using HamburgerProject.BLL.DTOs.UserDTOs;
using HamburgerProject.DATA.Concrete;
using HamburgerProject.DATA.Enums;
using HamburgerProjet.DAL.Abstractions;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerProject.BLL.Concrete
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ISiparisRepo _siparisRepo;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;

        public UserService(UserManager<AppUser> userManager, IMapper mapper, RoleManager<AppRole> roleManager, ISiparisRepo siparisRepo, SignInManager<AppUser> signInManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _siparisRepo = siparisRepo;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> AddUser(UserCreateDTO createDTO)
        {
            var appUser = _mapper.Map<AppUser>(createDTO);
            var result = await _userManager.CreateAsync(appUser,createDTO.Password);
            AppRole role = await _roleManager.FindByNameAsync("Member");
            if (role == null)
            {
                role = new AppRole();
                role.Name = "Member";
                _roleManager.CreateAsync(role);
            }
              await _userManager.AddToRoleAsync(appUser, role.Name);


         return result;
        }

        public async Task<IdentityResult>  DeleteUser(string Id)
        {

            var user = await _userManager.FindByIdAsync(Id);
            user.DeleteDate = DateTime.Now;
            user.Status = Status.Passive;
            IdentityResult result = await _userManager.UpdateAsync(user);
            return result;
        }

        public IList<UserDTO> GetAll()
        {
            IList<AppUser> users =  _userManager.Users.ToList();
            var userDTOs = _mapper.Map<IList<AppUser>,IList<UserDTO>>(users);
            return userDTOs;
        }

        public IList<SiparisDTO> GetByIdSiparis(string Id)
        {
            IList<Siparis> siparisler = _siparisRepo.GetDefaults(x=>x.AppUserId == Id);
            IList<SiparisDTO> siparisDTOs = _mapper.Map<IList<Siparis>, IList<SiparisDTO>>(siparisler);

            return siparisDTOs;
        }

        public async Task<bool> Login(LoginDTO loginDTO)
        {
            AppUser user =await _userManager.FindByNameAsync(loginDTO.UserName);
            if (user != null)
            {
                SignInResult result = await _signInManager.PasswordSignInAsync(user, loginDTO.Password, true, false);
                if (result.Succeeded)
                {
                    var userRoleManager = await _userManager.IsInRoleAsync(user, "Manager");
                    if (userRoleManager)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    throw new Exception("Hatalı Giriş");
                }
            } 
            else
            {
                throw new Exception("Kullanıcı Bulunamadı");
            }

        }
        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> UpdateUser(UserUpdateDTO updateDTO)
        {
            AppUser user = await _userManager.FindByIdAsync(updateDTO.Id);
            if (user.UserName != updateDTO.UserName)
            { user.UserName = updateDTO.UserName; }
            if (user.FirstName != updateDTO.FirstName)
            { user.FirstName = updateDTO.FirstName; }
            if (user.LastName != updateDTO.LastName)
            { user.LastName = updateDTO.LastName; }
            user.UpdateDate = DateTime.Now;
            user.Status = Status.Modified;
            IdentityResult result = await _userManager.UpdateAsync(user);

            return result;
       
        }

    }
}
