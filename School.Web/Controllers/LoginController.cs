using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using School.Data;
using School.Models;
using School.Repository.Shared.Abstract;
using System.Security.Claims;

namespace School.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;


        public LoginController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Verify(AppUser appUser)
        {

            AppUser user = _unitOfWork.AppUsers.GetFirstOrDefault(u => u.UserName == appUser.UserName && u.Password == appUser.Password);
            if (user != null)
            {
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, user.UserName));
                claims.Add(new Claim(ClaimTypes.GivenName, user.UserName));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                claims.Add(new Claim(ClaimTypes.Role, user.AppUserRole.RoleName));

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                return Json(user);
            }


            return Json(user);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
