using Microsoft.EntityFrameworkCore;
using SupplementStationDAL.Entities;
using SupplementStationDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementStationDAL.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private DataContext _dataContext;
        public CategoryRepository(DataContext dataContext) {
            _dataContext= dataContext;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _dataContext.Categories.ToListAsync();
        }
    }
}
