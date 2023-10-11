using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementStationDAL.Entities
{
    public class CartItem
    {
        [Key]
        public int CartItemId { get; set; }
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
        [Required]
        public int  ProductSizeId { get; set; }
        public ProductSize ProductSize { get; set; }
        [Required]
        public int Quantity { get; set; }


    }
}
