using Microsoft.AspNetCore.Mvc;
using OnlineBookShop.Data.UnitOfWork;
using OnlineBookShop.Models;
using OnlineBookShop.Services;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;

namespace OnlineBookShop.Controllers
{
    public class SessionController : Controller
    {

        private readonly IUnitOfWork unitOfWork;

        public SessionController(IUnitOfWork _unitOfWork)
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
                    if (userType != 2)
                    {
                        return RedirectToAction("Index", "Dashboard");
                    }
                    return RedirectToAction("Index", "Home");
                }
            }
            HttpContext.Session.Clear();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(User user)
        {
            IEnumerable<User> entity = unitOfWork.GetRepository<User>().GetAll();
            string token = UserService.GenerateJWTToken(user.Email, user.Password, entity);
            Debug.WriteLine(token);
            if (token != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadJwtToken(token);
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
                    return RedirectToAction("Index", "Home");
                }
            }

            return View();
        }

        public IActionResult SignUp()
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
                    if (userType != 2)
                    {
                        return RedirectToAction("Index", "Dashboard");
                    }
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignUp(User user)
        {
            var entity = unitOfWork.GetRepository<User>().GetAll();
            foreach (var member in entity)
            {
                if (user.Email == member.Email)
                {
                    return View();
                }
                else
                {
                    user.FullName = "Custom";
                    user.AddressDefaultID = 0;
                    user.UserType = 2;
                    user.CitizenID = "0000000";
                    unitOfWork.GetRepository<User>().Insert(user);
                    unitOfWork.SaveChanges();
                    Debug.WriteLine("Register Success!");
                    HttpContext.Session.SetInt32("CurrentUserID", user.UserID);
                    HttpContext.Session.SetInt32("CurrentUserType", user.UserType);
                    //Create cart
                    Cart cart = new Cart() { UserID = user.UserID, Cost = 0, TotalAmount = 0 };
                    unitOfWork.GetRepository<Cart>().Insert(cart);
                    unitOfWork.SaveChanges();
                    return RedirectToAction("Index", "Home");
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
