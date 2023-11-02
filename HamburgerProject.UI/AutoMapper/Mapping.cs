using AutoMapper;
using HamburgerProject.BLL.DTOs;
using HamburgerProject.BLL.DTOs.EkstraMalzemeDTOs;
using HamburgerProject.BLL.DTOs.MenuDTOs;
using HamburgerProject.BLL.DTOs.SiparisDTOs;
using HamburgerProject.BLL.DTOs.UserDTOs;
using HamburgerProject.DATA.Concrete;
using HamburgerProject.UI.Models.VMs;
using HamburgerProject.UI.Models.VMs.EkstraMalzemeVMs;
using HamburgerProject.UI.Models.VMs.MenuVMs;
using HamburgerProject.UI.Models.VMs.SiparisVMs;
using HamburgerProject.UI.Models.VMs.UserVMs;


namespace HamburgerProject.UI.AutoMapper
{
    public class Mapping :Profile
    {
        public Mapping() {
            CreateMap<SiparisDTO, SiparisVM>().ForMember(dest => dest.Menu, opt => opt.MapFrom(c => c.Menu)).ForMember(desc => desc.AppUser, opt => opt.MapFrom(c => c.AppUser)).ForMember(dest => dest.EkstraMalzemes, opt => opt.MapFrom(c => c.EkstraMalzemes)).ReverseMap();
            CreateMap<SiparisCreateDTO, SiparisCreateVM>().ForMember(dest => dest.EkstraMalzemes, opt => opt.MapFrom(c => c.EkstraMalzemes)).ForMember(desc => desc.Menus, opt => opt.Ignore()).ForMember(desc => desc.EkstraMalzemesIds, opt => opt.Ignore()).ReverseMap();
           CreateMap<SiparisDTO, SiparisUpdateVM>().ForMember(dest => dest.EkstraMalzemes, opt => opt.MapFrom(c => c.EkstraMalzemes)).ForMember(desc => desc.Menus, opt => opt.Ignore()).ForMember(desc => desc.EkstraMalzemesId, opt => opt.Ignore()).ReverseMap();
            CreateMap<SiparisUpdateDTO, SiparisUpdateVM>().ForMember(dest => dest.EkstraMalzemes, opt => opt.MapFrom(c => c.EkstraMalzemes)).ForMember(desc => desc.Menus, opt => opt.Ignore()).ForMember(desc => desc.EkstraMalzemesId, opt => opt.Ignore()).ReverseMap();
            
            CreateMap<SiparisUpdateVM,SiparisDTO>().ForMember(dest => dest.EkstraMalzemes, opt => opt.MapFrom(c => c.EkstraMalzemes)).ForMember(desc => desc.Menu, opt => opt.Ignore()).ForMember(desc => desc.AppUser, opt => opt.Ignore()).ReverseMap();

            CreateMap<UserDTO,UserVM>().ReverseMap();
            CreateMap<UserCreateDTO, UserCreateVM>().ReverseMap();
            CreateMap<LoginDTO, LoginVM>().ReverseMap();
            CreateMap<UserDTO, UserVM>().ReverseMap();

            CreateMap<EkstraMalzemeCreateDTO, EkstraMalzemeCreateVM>().ReverseMap();
            CreateMap<EkstraMalzemeDTO, EkstraMalzemeVM>().ReverseMap();
            CreateMap<EkstraMalzemeDTO,EkstraMalzemeUpdateVM>().ReverseMap();
            CreateMap<EkstraMalzemeUpdateDTO, EkstraMalzemeVM>().ReverseMap();
            CreateMap<EkstraMalzemeUpdateDTO, EkstraMalzemeUpdateVM>().ReverseMap();

            CreateMap<MenuCreateDTO, MenuCreateVM>().ReverseMap();
            CreateMap<MenuDTO, MenuVM>().ForMember(dest => dest.Siparisler, opt => opt.MapFrom(c => c.Siparisler)).ReverseMap();
            CreateMap<MenuUpdateVM, MenuDTO>().ForMember(dest => dest.Siparisler, opt => opt.Ignore()).ReverseMap();
            CreateMap<MenuUpdateDTO, MenuUpdateVM>().ReverseMap();


         

        }
    }
}
