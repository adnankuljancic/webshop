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
    
    public class ProductRepository : IProductRepository
    {
        DataContext _dataContext;
        public ProductRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IEnumerable<ProductSize> GetAll(int page = 1, string? search = null, int brand = 0, int category = 0, int orderBy = 0)
        {
            IQueryable<ProductSize> query = _dataContext.ProductSizes.Include(p => p.Product).Where(p => p.Quantity > 0);
            if (search != null)
            {
                query = query.Where(c => c.Product.ProductName.Contains(search));
            }
            if (brand != 0)
            {
                query = query.Where(c => c.Product.BrandId == brand);
            }
            if (category != 0)
            {
                query = query.Where(c => c.Product.CategoryId == category);
            }
            if (orderBy != 0)
            {
                if(orderBy == 2)
                {
                    query = query.OrderByDescending(c => c.Product.ProductName);
                } else
                {
                    query = query.OrderBy(c => c.Product.ProductName);
                }
            }
            //_dataContext.ProductSizes.Include(p => p.Product).Where(p => p.Quantity > 0).ToList().DistinctBy(p => p.ProductId);
            return query.Where(p => p.Quantity > 0).ToList().DistinctBy(p => p.ProductId).Skip((page-1)*3).Take(3);
        }
        public Product GetByID(int id)
        {
            return _dataContext.Products.FirstOrDefault(p => p.ProductId == id);
        }
        public IEnumerable<ProductSize> GetSizesByID(int id)
        {
            return _dataContext.ProductSizes.Include(p => p.Product).Where(p => p.ProductId == id).ToList();
        }
        public int AddProduct(Product product) { 
            _dataContext.Products.Add(product);
            _dataContext.SaveChanges();
            return product.ProductId;
        }
        public void AddProductSize(List<ProductSize> productSize)
        {
            _dataContext.ProductSizes.AddRange(productSize);
            _dataContext.SaveChanges();

        }
        public void DeleteById(int id)
        {
            var productSizes = _dataContext.ProductSizes.Where(p => p.ProductId == id).ToList();
            _dataContext.RemoveRange(productSizes);
            var product = _dataContext.Products.Find(id);
            _dataContext.Remove(product);
            _dataContext.SaveChanges();
        }
    }
}
