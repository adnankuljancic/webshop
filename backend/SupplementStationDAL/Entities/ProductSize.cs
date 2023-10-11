using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementStationDAL.Entities
{
    public class ProductSize
    {
        [Key]
        public int ProductSizeId { get; set; }
        [Required]
        public int Size { get; set; }
        [Required]
        [Precision(6, 2)]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        public int? Sold { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
