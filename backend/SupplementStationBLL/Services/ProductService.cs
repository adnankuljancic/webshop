using SupplementStationBLL.Interfaces;
using SupplementStationBLL.DTO;
using SupplementStationDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using SupplementStationDAL.Entities;
using AutoMapper;

namespace SupplementStationBLL.Services
{

    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public IEnumerable<DTO.ProductDto> GetAll(FiltersDto filters)
        {
            return _productRepository.GetAll(filters.page, filters.search, filters.brand , filters.category, filters.orderBy).Select(product => new DTO.ProductDto()
            {
                productId = product.ProductId,
                productName = product.Product.ProductName,
                productDescription = product.Product.ProductDescription,
                image = product.Product.Image
            });
        }


        public NewProduct GetByID(int id)
        {
            NewProduct product = _mapper.Map<NewProduct>( _productRepository.GetByID(id));
            product.productSizeList = _mapper.Map<List<NewProductSize>>(_productRepository.GetSizesByID(id));
         
            return product;
        }

        public void AddProduct(NewProduct newProduct)
        {
            var productToAdd = _mapper.Map<Product>(newProduct);
            int productId = _productRepository.AddProduct(productToAdd);
            var productSizes = _mapper.Map<List<ProductSize>>(newProduct.productSizeList);
            productSizes.ForEach(_ => _.ProductId = productId);
            _productRepository.AddProductSize(productSizes);
        }
        public void DeleteById(int id)
        {
            _productRepository.DeleteById(id);
        }
    }
}
