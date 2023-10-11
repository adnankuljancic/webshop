using SupplementStationDAL.Entities;
using SupplementStationDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementStationDAL.Repository
{
    public class UserRepository : IUserRepository
    {
        DataContext _dataContext;
        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void Register(User user)
        {
            _dataContext.Users.Add(user);
            _dataContext.SaveChanges();
            int id = GetUserByEmail(user.Email).UserId;
            UserRole ur = new UserRole()
            {
                UserId = id,
                RoleId = 2
            };
            _dataContext.UserRole.Add(ur);
            _dataContext.SaveChanges();
        }
        public User GetUserByEmail(string email)
        {
            return _dataContext.Users.FirstOrDefault(u => u.Email==email);
        }
        public int GetUserRole(int id)
        {
            return _dataContext.UserRole.FirstOrDefault(u => u.UserId == id).RoleId;
        }
    }
}
