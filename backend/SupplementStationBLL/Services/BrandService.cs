using AutoMapper;
using SupplementStationBLL.DTO;
using SupplementStationBLL.Interfaces;
using SupplementStationDAL.Entities;
using SupplementStationDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementStationBLL.Services
{
    public class BrandService : IBrandService
    {
        private IBrandRepository _brandRepository;
        private IMapper _mapper;
        public BrandService(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }
        public IEnumerable<BrandDto> GetAllBrands()
        {
            return _mapper.Map<IEnumerable<BrandDto>>(_brandRepository.GetAllBrands());
        }
    }
}
