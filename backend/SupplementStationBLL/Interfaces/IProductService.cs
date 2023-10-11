using SupplementStationBLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementStationBLL.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetAll(FiltersDto filters);
        NewProduct GetByID(int id);
        void AddProduct(NewProduct newProduct);
        void DeleteById(int id);
    }
}
