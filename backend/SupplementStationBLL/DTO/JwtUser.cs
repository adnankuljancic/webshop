using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementStationBLL.DTO
{
    public class JwtUser
    {
        public string jwt { get; set; } = string.Empty;
        public int role { get; set; } = 0;
        public int userId { get; set; } = 0;
    }
}
