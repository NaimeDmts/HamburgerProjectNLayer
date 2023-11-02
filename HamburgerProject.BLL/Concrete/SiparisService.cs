using AutoMapper;
using HamburgerProject.BLL.Abstractions;
using HamburgerProject.BLL.DTOs.SiparisDTOs;
using HamburgerProject.DATA.Concrete;
using HamburgerProject.DATA.Enums;
using HamburgerProjet.DAL.Abstractions;
using HamburgerProjet.DAL.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerProject.BLL.Concrete
{
    public class SiparisService : ISiparisService
    {
        private readonly ISiparisRepo _repo;
        private readonly ISiparisMalzemeRepo _sRepo;
        private readonly IEkstraMalzemeRepo _EMrepo;
        private readonly IMapper _mapper;

        public SiparisService(ISiparisRepo repo, ISiparisMalzemeRepo sRepo, IEkstraMalzemeRepo eMrepo, IMapper mapper)
        {
            _repo = repo;
            _sRepo = sRepo;
            _EMrepo = eMrepo;
            _mapper = mapper;
        }

        public void AddSiparis(SiparisCreateDTO createDTO)
        {
          var siparis = _mapper.Map<Siparis>(createDTO);

            if (createDTO.EkstraMalzemes != null && createDTO.EkstraMalzemes.Any())
            {
                siparis.SiparisMalzemes = createDTO.EkstraMalzemes
                    .Select(em => new SiparisMalzeme
                    {
                        EkstraMalzemeId = em.Id
                      
                    })
                    .ToList();
            }
            _repo.AddSiparis(siparis);
        }

        public void DeleteSiparis(int id)
        {
            var siparis = _repo.GetById(id);
            siparis.DeleteDate = DateTime.Now;
            siparis.Status = Status.Passive;
            _repo.Delete(siparis);

        }

        public IList<SiparisDTO> GetAll()
        {
            IList< Siparis> siparisler= _repo.GetAll();
            IList<SiparisDTO> siparislerDTO = _mapper.Map<IList<Siparis>, IList<SiparisDTO>>(siparisler);
            return siparislerDTO;
        }

        public SiparisDTO GetByIdSiparis(int Id)
        {
            Siparis siparis = _repo.GetById(Id);
            SiparisDTO siparisDTO = _mapper.Map<SiparisDTO>(siparis);
            return siparisDTO;
        }

        public IList<SiparisDTO> GetNotPassiveAll()
        {
           
            IList<Siparis> siparisler = _repo.GetNotPassiveAll();
            IList<SiparisDTO> siparislerDTO = _mapper.Map<List<Siparis>, List<SiparisDTO>>(siparisler.ToList());
            return siparislerDTO;
        }

        public void UpdateSiparis(SiparisUpdateDTO updateDTO)
        {
            var siparis = _mapper.Map<Siparis>(updateDTO);
         
            if (updateDTO.EkstraMalzemes != null && updateDTO.EkstraMalzemes.Any())
            {
                var siparisMalzeme = _sRepo.GetDefaults(x => x.SiparisId == updateDTO.Id);
                foreach (var sm in siparisMalzeme)
                {
                    _sRepo.Delete(sm);
                }

                foreach (var ekstraMalzeme in updateDTO.EkstraMalzemes)
                {
                    var newSiparisMalzeme = new SiparisMalzeme
                    {
                        SiparisId = updateDTO.Id,
                        EkstraMalzemeId = ekstraMalzeme.Id,
                   
                    };

                    _sRepo.Add(newSiparisMalzeme);
                }


            }
            siparis.UpdateDate = DateTime.Now;
            siparis.Status = Status.Modified;
            _repo.UpdateSiparis(siparis);
        }

    }
}
