using AutoMapper;
using SupplementStationBLL.DTO;
using SupplementStationBLL.Interfaces;
using SupplementStationDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementStationBLL.Services
{
    public class CategoryService: ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        private IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper) {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CategoryDto>> GetAllCategories()
        {
            throw new NotImplementedException();
            return _mapper.Map<IEnumerable<CategoryDto>>(await _categoryRepository.GetAllCategories());
            
        }
    }
}
