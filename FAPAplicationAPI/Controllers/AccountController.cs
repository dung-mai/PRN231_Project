using Microsoft.AspNetCore.Mvc;

namespace FAPAplicationAPI.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
