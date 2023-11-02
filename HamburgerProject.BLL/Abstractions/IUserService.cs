using HamburgerProject.BLL.DTOs.SiparisDTOs;
using HamburgerProject.BLL.DTOs.UserDTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerProject.BLL.Abstractions
{
    public interface IUserService
    {
        Task<IdentityResult> AddUser(UserCreateDTO createDTO);
        Task<IdentityResult> DeleteUser(string Id);
        Task<IdentityResult> UpdateUser(UserUpdateDTO updateDTO);
        IList<SiparisDTO> GetByIdSiparis(string Id);
        Task<bool> Login(LoginDTO loginDTO);
        Task LogOut();

        IList<UserDTO> GetAll();


    }
}
