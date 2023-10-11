using Microsoft.IdentityModel.Tokens;
using SupplementStationBLL.Interfaces;
using SupplementStationBLL.DTO;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using SupplementStationDAL.Interfaces;
using SupplementStationDAL.Entities;

namespace SupplementStationBLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        public AuthService (IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public static DTO.User user = new DTO.User();
        

        public void Register(NewUser request)
        {
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            _userRepository.Register(new SupplementStationDAL.Entities.User()
            {
                Name = request.Name,
                LastName= request.LastName,
                Email  = request.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            });
 
        }
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt) 
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        public JwtUser Login(DTO.User request, string key)
        {
            JwtUser jwtUser = new JwtUser();
            SupplementStationDAL.Entities.User userEntity = _userRepository.GetUserByEmail(request.Email);
            if (userEntity.Email != request.Email || !VerifyPasswordHash(request.Password, userEntity.PasswordHash, userEntity.PasswordSalt))
            {
                return jwtUser;
            } 
            jwtUser.jwt = createToken(userEntity, key);
            jwtUser.role = _userRepository.GetUserRole(userEntity.UserId);
            jwtUser.userId= userEntity.UserId;


            return jwtUser;

        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        private string createToken(SupplementStationDAL.Entities.User user, string secretKey)
        {

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, "Admin")
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
              claims: claims,
              expires: DateTime.Now.AddDays(1),
              signingCredentials: creds);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
