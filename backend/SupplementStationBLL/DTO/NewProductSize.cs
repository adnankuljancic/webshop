using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementStationBLL.DTO
{
    public class NewProductSize
    {
        public int? ProductSizeId { get; set; }
        public int Size { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public ProductDto? Product { get; set; }
    }
}
