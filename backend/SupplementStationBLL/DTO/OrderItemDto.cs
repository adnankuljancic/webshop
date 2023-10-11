﻿using Microsoft.EntityFrameworkCore;
using SupplementStationDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementStationBLL.DTO
{
    public class OrderItemDto
    {
        public int? OrderItemId { get; set; }
        public int? OrderId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
