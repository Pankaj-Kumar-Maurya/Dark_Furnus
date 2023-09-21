using Microsoft.AspNetCore.Mvc;

namespace Dark_Furnus.Controllers
{
    public class LogInController : Controller
    {
        public IActionResult LoginForm()
        {
            return View();
        }
    }
}
