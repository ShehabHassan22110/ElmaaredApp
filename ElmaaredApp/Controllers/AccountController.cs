using Microsoft.AspNetCore.Mvc;

namespace ElmaaredApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult ResetPassword()
        {
            return View();
        }
    }
}
