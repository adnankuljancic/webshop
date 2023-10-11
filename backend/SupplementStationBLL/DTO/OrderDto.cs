using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementStationBLL.DTO
{
    public class OrderDto
    {
        public int? OrderId { get; set; }
        public int UserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public List<OrderItemDto> orderItemsList { get; set; }
    }
}
