using SupplementStationBLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementStationBLL.Interfaces
{
    public interface IBrandService
    {
        IEnumerable<BrandDto> GetAllBrands();
    }
}
