using Microsoft.IdentityModel.Tokens;
using OnlineBookShop.Models;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OnlineBookShop.Services
{
    public class UserService : IUserService
    {

        public static string GenerateJWTToken(string email, string password, IEnumerable<User> userList)
        {
            var userAuthenticate = new UserAuthenticateModel();
            var user = userList.SingleOrDefault(user => user.Email == email && user.Password == password);
            if (user != null)
            {
                userAuthenticate.UserID = user.UserID;
                userAuthenticate.UserType = user.UserType;
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes("OnlineBookShopMakeByKamii123456789");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(
                        new[]
                        {
                        new Claim("UserID", userAuthenticate.UserID.ToString()),
                        new Claim("UserType", userAuthenticate.UserType.ToString())
                        }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            return null;

        }

        public static string GenerateJWTTokenAdmin(string email, string password, IEnumerable<Staff> staffList)
        {
            var userAuthenticate = new UserAuthenticateModel();
            var user = staffList.FirstOrDefault(staff => staff.Email == email && staff.Password == password);
            if (user != null)
            {
                userAuthenticate.UserID = user.StaffID;
                userAuthenticate.UserType = user.UserType;
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes("OnlineBookShopMakeByKamii123456789");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(
                        new[]
                        {
                        new Claim("UserID", userAuthenticate.UserID.ToString()),
                        new Claim("UserType", userAuthenticate.UserType.ToString())
                        }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            return null;

        }

        public static bool IsTokenExpired(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtTokenObj = tokenHandler.ReadJwtToken(token);
            // Retrieve the token's expiration time
            var expires = jwtTokenObj.ValidTo;
            Debug.WriteLine(expires);
            // Check if the token has expired
            var isExpired = DateTime.UtcNow > expires;

            return isExpired;
        }

    }
}
