using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementStationBLL.DTO
{
    public class FiltersDto
    {
        public string? search { get; set; } = string.Empty;
        public int orderBy { get; set; }
        public int page { get; set; }
        public int category { get; set; }
        public int brand { get; set; }
    }
}
