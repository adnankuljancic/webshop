using Microsoft.EntityFrameworkCore;
using SupplementStationDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementStationDAL
{
    public class ProductDbContextConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Product> builder) { 
            builder.Property(product => product.ProductDescription).HasMaxLength(150);
            builder.HasData(new[] { new Product() { ProductId=-1, ProductName="Protein", ProductDescription= "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris gravida elit vel tellus facilisis, dapibus.", 
            Image="https://cdn.shopify.com/s/files/1/1525/5556/products/whey-matrix-quad-blend-whey-protein-complex-545871_1024x1024.jpg?v=1657561376"} });
        }
    }
}
