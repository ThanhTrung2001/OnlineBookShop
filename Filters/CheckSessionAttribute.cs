using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OnlineBookShop.Services;

namespace OnlineBookShop.Filters
{
    public class CheckSessionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = filterContext.HttpContext.Session;
            var token = filterContext.HttpContext.Session.GetString("token");

            if (token == null || UserService.IsTokenExpired(token) == true)
            {
                filterContext.HttpContext.Session.Clear();
                filterContext.Result = new RedirectResult("Login"); // Redirect to the login action of the Account controller
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
