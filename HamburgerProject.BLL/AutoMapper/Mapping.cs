using AutoMapper;
using HamburgerProject.BLL.DTOs.EkstraMalzemeDTOs;
using HamburgerProject.BLL.DTOs.MenuDTOs;
using HamburgerProject.BLL.DTOs.SiparisDTOs;
using HamburgerProject.BLL.DTOs.UserDTOs;
using HamburgerProject.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerProject.BLL.AutoMapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Siparis, SiparisCreateDTO>().ForMember(dest => dest.EkstraMalzemes, opt => opt.Ignore()).ReverseMap();
            CreateMap<Siparis, SiparisDTO>().ForMember(dest => dest.Menu, opt => opt.MapFrom(c => c.Menu)).ForMember(dest => dest.AppUser, opt => opt.MapFrom(c => c.AppUser)).ForMember(dest => dest.EkstraMalzemes, opt => opt.MapFrom(src => src.SiparisMalzemes.Select(sm => sm.EkstraMalzeme))).ReverseMap();
            CreateMap<Siparis, SiparisUpdateDTO>().ReverseMap();

            CreateMap<Menu, MenuDTO>().ForMember(dest => dest.Siparisler, opt => opt.MapFrom(c => c.Siparisler)).ReverseMap();
            CreateMap<Menu, MenuCreateDTO>().ReverseMap();
            CreateMap<Menu, MenuUpdateDTO>().ReverseMap();

            CreateMap<EkstraMalzeme, EkstraMalzemeCreateDTO>().ReverseMap();
            CreateMap<EkstraMalzeme, EkstraMalzemeDTO>().ReverseMap();
            CreateMap<EkstraMalzeme, EkstraMalzemeUpdateDTO>().ReverseMap();

            CreateMap<AppUser, UserCreateDTO>().ReverseMap();
            CreateMap<AppUser, UserUpdateDTO>().ReverseMap();
            CreateMap<AppUser, UserDTO>().ReverseMap();
            CreateMap<AppUser, LoginDTO>().ReverseMap();

        }
    }
}
