using AutoMapper;
using HamburgerProject.BLL.Abstractions;
using HamburgerProject.BLL.DTOs.EkstraMalzemeDTOs;
using HamburgerProject.DATA.Concrete;
using HamburgerProject.DATA.Enums;
using HamburgerProjet.DAL.Abstractions;
using HamburgerProjet.DAL.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerProject.BLL.Concrete
{
    public class EkstraMalzemeService : IEkstraMalzemeService
    {
        private readonly IEkstraMalzemeRepo _repo;
        private readonly IMapper _mapper;

        public EkstraMalzemeService(IEkstraMalzemeRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public void AddEkstraMalzeme(EkstraMalzemeCreateDTO createDTO)
        {
            var ekstraMalzeme = _mapper.Map<EkstraMalzeme>(createDTO);
            _repo.Add(ekstraMalzeme);
        }

        public void DeleteEkstraMalzeme(int id)
        {
           var ekstraMalzeme = _repo.GetById(id);
            ekstraMalzeme.DeleteDate = DateTime.Now;
            ekstraMalzeme.Status = Status.Passive;
            _repo.Delete(ekstraMalzeme);
        }

        public IList<EkstraMalzemeDTO> GetAll()
        {
            IList<EkstraMalzeme> ekstraMalzemes = _repo.GetAll();
            IList<EkstraMalzemeDTO> ekstraMalzemeDTOs = _mapper.Map<IList<EkstraMalzeme>, IList<EkstraMalzemeDTO>>(ekstraMalzemes);
            return ekstraMalzemeDTOs;
        }

        public EkstraMalzemeDTO GetByIdEkstraMalzeme(int Id)
        {
            var ekstraMalzeme = _repo.GetById(Id);
            var ekstraMalzemeDTO = _mapper.Map<EkstraMalzemeDTO>(ekstraMalzeme);
            return ekstraMalzemeDTO;

        }

        public  EkstraMalzemeUpdateDTO GetDefaultsEM(int id)
        {
            var ekstraMalzeme =  _repo.GetDefaultsEM(id);
            EkstraMalzemeUpdateDTO ekstraDTO = _mapper.Map<EkstraMalzemeUpdateDTO>(ekstraMalzeme);
            return ekstraDTO;
        }

        public IList<EkstraMalzemeDTO> GetNotPassiveAll()
        {

            IList<EkstraMalzeme> ekstraMalzemes = _repo.GetNotPassiveAll();
            IList<EkstraMalzemeDTO> ekstraMalzemeDTOs = _mapper.Map<IList<EkstraMalzeme>, IList<EkstraMalzemeDTO>>(ekstraMalzemes);
            return ekstraMalzemeDTOs;
        }

        public void UpdateEkstraMalzeme(EkstraMalzemeUpdateDTO updateDTO)
        {
           var ekstraMalzeme = _mapper.Map<EkstraMalzeme>(updateDTO);
            ekstraMalzeme.UpdateDate = DateTime.Now;
            ekstraMalzeme.Status = Status.Modified;
            _repo.Update(ekstraMalzeme);
        }
    }
}
