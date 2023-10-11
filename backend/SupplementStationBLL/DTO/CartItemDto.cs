using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementStationBLL.DTO
{
    public class CartItemDto
    {
        /// <summary>
        /// Gets or sets uique identity for user.
        /// </summary>
        ///
        public int CartItemId { get; set; } = 0;
        public int UserId { get; set; } = 0;
        public int ProductSizeId { get; set; } = 0;
        public int Quantity { get; set; } = 0;
        public NewProductSize? ProductSize { get; set; }

    }
}
