using SupplementStationDAL.Entities;
using SupplementStationDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementStationDAL.Repository
{
    public class BrandRepository : IBrandRepository
    {
        private DataContext _dataContext;
        public BrandRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<Brand> GetAllBrands()
        {
            return _dataContext.Brands.ToList();
        }
    }
}
