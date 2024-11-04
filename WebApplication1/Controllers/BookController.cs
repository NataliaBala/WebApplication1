using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApp.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save(Book model)
        {
            if (ModelState.IsValid)
            {
                return View("Success", model);
            }
            else
            {
                return View("Form", model);
            }
        }
    }
}