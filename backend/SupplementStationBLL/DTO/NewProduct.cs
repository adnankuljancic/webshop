using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementStationBLL.DTO
{
    public class NewProduct
    {
        public int? ProductId { get; set; }
        public string productName { get; set; } = "string";
        public string productDescription { get; set; } = "string";
        public string image { get; set; } = "string";
        public int BrandId { get; set; } = 0;
        public int CategoryId { get; set; } = 0;
        public List<NewProductSize> productSizeList { get; set; }
    }
}
