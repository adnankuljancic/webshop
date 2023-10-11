using SupplementStationBLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementStationBLL.Interfaces
{
    public interface IAuthService
    {
        void Register(NewUser request);
        JwtUser Login(User request, string key);
    }
}
