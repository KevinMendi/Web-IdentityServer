using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace ContosoUniversity.Controllers
{
    public class LoginController : Controller
    {

        public IActionResult Login()
        {
            return Challenge(new AuthenticationProperties() { RedirectUri = "Home/Index" },

            Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectDefaults.AuthenticationScheme);

        }

        public IActionResult Logout()
        {
            return SignOut(new AuthenticationProperties() { RedirectUri = "Home/Index" },

            Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectDefaults.AuthenticationScheme,

            Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme);

        }
    }
}
