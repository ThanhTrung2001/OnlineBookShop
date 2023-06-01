using Microsoft.AspNetCore.Mvc;
using OnlineBookShop.Data.UnitOfWork;
using OnlineBookShop.Models;
using OnlineBookShop.Services;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;

namespace OnlineBookShop.Controllers
{
    public class StaffSessionController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public StaffSessionController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public IActionResult Login()
        {
            string? currentToken = HttpContext.Session.GetString("Token");
            if (currentToken != null && UserService.IsTokenExpired(currentToken) == false)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadJwtToken(currentToken);
                Debug.WriteLine(jwtToken);
                // Retrieve the UserID and UserType claims from the token
                var userIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "UserID");
                var userTypeClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "UserType");
                // Get the string values
                var userIdReceive = userIdClaim.Value;
                var userTypeReceive = userTypeClaim.Value;
                if (userIdReceive != null && userTypeReceive != null)
                {
                    //Exchange to int
                    int userId = int.Parse(userIdReceive);
                    int userType = int.Parse(userTypeReceive);
                    HttpContext.Session.SetString("Token", currentToken);
                    HttpContext.Session.SetInt32("CurrentUserID", userId);
                    HttpContext.Session.SetInt32("CurrentUserType", userType);
                    if (userType != 0 && userType != 1)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    return RedirectToAction("Index", "Dashboard");
                }
            }
            HttpContext.Session.Clear();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Staff staff)
        {
            IEnumerable<Staff> entity = unitOfWork.GetRepository<Staff>().GetAll();
            if (staff.Email == "admin@gmail.com" && staff.Password == "admin")
            {
                string tokenAdmin = UserService.GenerateJWTTokenAdmin(staff.Email, staff.Password, entity);
                HttpContext.Session.SetString("Token", tokenAdmin);
                HttpContext.Session.SetInt32("CurrentUserID", 0);
                HttpContext.Session.SetInt32("CurrentUserType", 0);
                return RedirectToAction("Index", "Dashboard");
            }
            string token = UserService.GenerateJWTTokenAdmin(staff.Email, staff.Password, entity);
            if (token != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadJwtToken(token);
                Debug.WriteLine(jwtToken);
                // Retrieve the UserID and UserType claims from the token
                var userTypeClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "UserType");
                var userIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "UserID");
                var userIdReceive = userIdClaim.Value;
                var userTypeReceive = userTypeClaim.Value;
                Debug.WriteLine(UserService.IsTokenExpired(token));
                Debug.WriteLine(userIdReceive + " , " + userTypeReceive);
                if (userIdReceive != null && userTypeReceive != null)
                {
                    int userId = int.Parse(userIdReceive);
                    int userType = int.Parse(userTypeReceive);
                    HttpContext.Session.SetString("Token", token);
                    HttpContext.Session.SetInt32("CurrentUserID", userId);
                    HttpContext.Session.SetInt32("CurrentUserType", userType);
                    return RedirectToAction("Index", "Dashboard");
                }
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
