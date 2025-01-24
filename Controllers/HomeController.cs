
using Microsoft.AspNetCore.Mvc;

namespace Zaliczenie.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}