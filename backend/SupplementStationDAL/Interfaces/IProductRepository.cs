using SupplementStationDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementStationDAL.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<ProductSize> GetAll(int page = 1, string? search = null, int brand = 0, int category = 0, int orderBy = 0);
        Product GetByID(int id);
        IEnumerable<ProductSize> GetSizesByID(int id);
        int AddProduct(Product product);
        void AddProductSize(List<ProductSize> productSize);
        void DeleteById(int id);
    }
}
