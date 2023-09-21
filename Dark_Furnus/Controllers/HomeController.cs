using Dark_Furnus.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Dark_Furnus.Controllers
{
    public class HomeController : Controller
    {
    public readonly DatabaseContext db;

        public HomeController(DatabaseContext database)
        {
            this.db = database;
        }
        public IActionResult Index()
        {
          return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}